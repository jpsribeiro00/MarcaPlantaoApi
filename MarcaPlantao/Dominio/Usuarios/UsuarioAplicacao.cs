using MarcaPlantao.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Usuarios
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor acesso;

        public UsuarioAplicacao(Microsoft.AspNetCore.Http.IHttpContextAccessor acesso)
        {
            this.acesso = acesso;
        }

        public string Nome => acesso.HttpContext.User.Identity.Name;

        public bool EstaAutenticado()
        {
            return acesso.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> ObterClaimsIdentity()
        {
            return acesso.HttpContext.User.Claims;
        }
    }
}
