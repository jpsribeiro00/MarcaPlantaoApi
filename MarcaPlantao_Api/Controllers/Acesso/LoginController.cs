using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Acesso;
using MarcaPlantao.Aplicacao.Servicos.Acesso;
using MarcaPlantao.Dominio.Usuarios;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Servico.Controllers;
using MarcaPlantao_Servico.Identidade;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarcaPlantao_Api.Controllers.Acesso
{
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ApiControllerBase
    {
        private readonly IAutenticacaoServico servicoAutenticacao;
        private readonly ConfiguracaoApp configuracaoApp;

        public LoginController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IAutenticacaoServico servicoAutenticacao, IOptions<ConfiguracaoApp> configuracaoApp) : base(notifications, mediator)
        {
            this.servicoAutenticacao = servicoAutenticacao;
            this.configuracaoApp = configuracaoApp.Value;
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> RegistrarUsuario(ApplicationUserDados registerUser)
        {
            if (!ModelState.IsValid) return Response(registerUser);

            var result = await servicoAutenticacao.RegistrarUsuario(registerUser, "Profissional", "Adicionar");

            return Response(await GerarToken(result.Email));
        }

        [HttpPost("RegistrarAdministrador")]
        public async Task<IActionResult> RegistrarAdministrador(AdministratorUserDados registerUser)
        {
            if (!ModelState.IsValid) return Response(registerUser);

            await servicoAutenticacao.RegistrarAdministrador(registerUser, "Administrador", "Adicionar");

            return Response();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromQuery] string email, string senha)
        {
            var result = await servicoAutenticacao.Login(email,senha,false,true);
            result.Token = await GerarToken(email);

            return Response(result);
        }

        private async Task<string> GerarToken(string Email)
        {
            var user = await servicoAutenticacao.RetornarUsuario(Email);
            var claims = await servicoAutenticacao.RetornarClaims(user);
            var userRoles = await servicoAutenticacao.RetornarRoles(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(configuracaoApp.Segredo);

            var descricaoToken = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(configuracaoApp.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature),
                Issuer = configuracaoApp.Emissor,
                Audience = configuracaoApp.ValidoEm
            };

            var token = tokenHandler.CreateToken(descricaoToken);
            return tokenHandler.WriteToken(token);
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
