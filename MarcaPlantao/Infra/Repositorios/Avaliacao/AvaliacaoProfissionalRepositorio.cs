using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Avaliacao
{
    public class AvaliacaoProfissionalRepositorio : Repository<AvaliacaoProfissional>, IAvaliacaoProfissionalRepositorio
    {
        public AvaliacaoProfissionalRepositorio(ContextoMarcaPlantao db) : base(db)
        {
        }
    }
}
