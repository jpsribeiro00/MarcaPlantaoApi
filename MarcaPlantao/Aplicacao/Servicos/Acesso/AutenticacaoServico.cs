using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.ProfissionalComandos;
using MarcaPlantao.Aplicacao.Dados.Acesso;
using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao.Aplicacao.Dados.Usuario;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Dominio.Usuarios;
using MarcaPlantao.Infra.Contexto;
using MarcaPlantao.Infra.Repositorios.Profissionais;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MarcaPlantao.Aplicacao.Servicos.Acesso
{
    public class AutenticacaoServico : IAutenticacaoServico
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext appDbContext;
        private readonly IMediatorHandler mediadorHandler;
        private readonly IMapper mapper;
        private readonly IProfissionalRepositorio profissionalRepositorio;

        public AutenticacaoServico(UserManager<ApplicationUser> userManager, 
            AppDbContext appDbContext,
            SignInManager<ApplicationUser> signInManager,
            IMediatorHandler mediadorHandler,
            IMapper mapper,
            IProfissionalRepositorio profissionalRepositorio)
        {
            _userManager = userManager;
            this.appDbContext = appDbContext;
            _signInManager = signInManager;
            this.mediadorHandler = mediadorHandler;
            this.mapper = mapper;
            this.profissionalRepositorio = profissionalRepositorio;
        }

        public async Task<ObterUsuarioProfissional> RegistrarUsuario(ApplicationUserDados user, string role, string claims)
        {
            if (!(await this.profissionalRepositorio.ValidarProfissional(user.CRM, user.CPF)))
            {
                ApplicationUser usuario = mapper.Map<ApplicationUser>(user);

                var result = await _userManager.CreateAsync(usuario, user.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(usuario, new Claim(role, claims));

                    ApplicationUser resultUser = await _userManager.FindByIdAsync(usuario.Id);

                    await _userManager.UpdateAsync(resultUser);

                    var usuarioProfissional = mapper.Map<ObterUsuarioProfissional>(await RegistrarProfissional(user, resultUser.Id));
                    usuarioProfissional.Email = resultUser.Email;

                    return usuarioProfissional;
                }
                foreach (var error in result.Errors)
                {
                    await mediadorHandler.PublicarNotificacao(new NotificacaoDominio("RegistrarUsuario", error.Description));
                }
            }
            else 
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio("RegistrarUsuario", "CRM ou CPF informados já foram cadastrados!"));
            }

            return null;
        }

        public async Task<Profissional> RegistrarProfissional(ApplicationUserDados user, string UserId) 
        {
            var profissional = new ProfissionalDados();
            profissional.Nome = user.Nome;

            if (user.Imagem != null && user.Imagem.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    user.Imagem.CopyTo(ms);
                    profissional.Imagem = ms.ToArray();
                }
            }
            else
            {
                profissional.Imagem = null;
            }

            profissional.DataNascimento = user.DataNascimento;
            profissional.Telefone = user.Telefone;
            profissional.UserId = UserId;
            profissional.Genero = user.Genero;
            profissional.CPF = user.CPF;
            profissional.CRM = user.CRM;
            profissional.Especializacoes = user.Especializacoes;

            await mediadorHandler.EnviarComando(mapper.Map<AdicionarProfissionalComando>(profissional));

            return await ObterUsuarioProfissional(UserId);
        }

        public async Task<Profissional> ObterUsuarioProfissional(string UserId) 
        {
            return await profissionalRepositorio.ObterProfissionalPorUsuario(UserId);
        }

        public async Task RegistrarAdministrador(AdministratorUserDados user, string role, string claims)
        {
            ApplicationUser usuario = mapper.Map<ApplicationUser>(user);

            IdentityResult result = await _userManager.CreateAsync(usuario, user.Password);
            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(usuario, new Claim(role, claims));
            }
            foreach (var error in result.Errors)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio("RegistrarUsuario", error.Description));
            }
        }

        public async Task<ObterUsuario> Login(string email, string senha, bool isPersistent, bool lockoutOnFailure)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(email, senha, false, true);

            if (result.Succeeded)
            {
                var resultUser = await RetornarUsuario(email);

                if(resultUser.ClinicaId == null) 
                {
                    var usuarioProfissional = mapper.Map<ObterUsuarioProfissional>(await ObterUsuarioProfissional(resultUser.Id));
                    usuarioProfissional.Email = resultUser.Email;

                    return usuarioProfissional;
                }
                else 
                {
                    return mapper.Map<ObterUsuarioAdministrador>(resultUser);
                }
                
            }
            if(result.IsNotAllowed)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio("Login", "Usuário e/ou senha inválidos"));
            }
            if (result.IsLockedOut) 
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio("Login", "Usuário desativado"));
            }

            return null;
        }

        public async Task<List<ObterUsuarioAdministrador>> ObterAdministradoresPorClinica(Guid clinicaId)
        {
            return mapper.Map<List<ObterUsuarioAdministrador>>(await appDbContext.Users.Where(x => x.ClinicaId == clinicaId).ToListAsync());
        }

        public async Task<ApplicationUser> RetornarUsuario(string Email)
        {
            return await _userManager.FindByEmailAsync(Email);
        }

        public async Task<IList<Claim>> RetornarClaims(ApplicationUser applicationUser)
        {
            return await _userManager.GetClaimsAsync(applicationUser);
        }

        public async Task<IList<string>> RetornarRoles(ApplicationUser applicationUser)
        {
            return await _userManager.GetRolesAsync(applicationUser);
        }
    }
}
