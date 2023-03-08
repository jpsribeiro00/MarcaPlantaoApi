using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Interfaces
{
    public interface IUsuarioAplicacao
    {
        string Nome { get; }
        bool EstaAutenticado();
        IEnumerable<Claim> ObterClaimsIdentity();
    }
}
