using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Acesso
{
    public class ObterUsuarioAdministrador : ObterUsuario
    {
        public bool Master { get; set; }
        public Guid ClinicaId { get; set; }
    }
}
