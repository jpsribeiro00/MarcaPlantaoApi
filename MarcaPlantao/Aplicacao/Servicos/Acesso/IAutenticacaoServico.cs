using MarcaPlantao.Aplicacao.Dados.Acesso;
using MarcaPlantao.Aplicacao.Dados.Usuario;
using MarcaPlantao.Dominio.Usuarios;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MarcaPlantao.Aplicacao.Servicos.Acesso
{
    public interface IAutenticacaoServico
    {
        Task<ObterUsuarioProfissional> RegistrarUsuario(ApplicationUserDados user, string role, string claims);

        Task RegistrarAdministrador(AdministratorUserDados user, string role, string claims);

        Task<ApplicationUser> RetornarUsuario(string email);

        Task<IList<Claim>> RetornarClaims(ApplicationUser applicationUser);

        Task<IList<string>> RetornarRoles(ApplicationUser applicationUser);

        Task<ObterUsuario> Login(string email, string senha, bool isPersistent, bool lockoutOnFailure);

        Task<List<ObterUsuarioAdministrador>> ObterAdministradoresPorClinica(Guid clinicaId);
    }
}
