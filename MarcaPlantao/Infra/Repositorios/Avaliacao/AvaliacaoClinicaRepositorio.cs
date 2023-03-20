using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Avaliacao
{
    public class AvaliacaoClinicaRepositorio : Repository<AvaliacaoClinica>, IAvaliacaoClinicaRepositorio
    {
        public AvaliacaoClinicaRepositorio(ContextoMarcaPlantao db) : base(db)
        {
        }
    }
}
