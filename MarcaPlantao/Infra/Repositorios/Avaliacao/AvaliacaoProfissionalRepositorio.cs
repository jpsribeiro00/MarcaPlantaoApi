using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<AvaliacaoProfissional>> ObterPorPlantaoId(Guid plantaoId) 
        {
            return await Db.AvaliacaoProfissionais.AsNoTracking().Where(x => x.PlantaoId == plantaoId).ToListAsync();
        }
    }
}
