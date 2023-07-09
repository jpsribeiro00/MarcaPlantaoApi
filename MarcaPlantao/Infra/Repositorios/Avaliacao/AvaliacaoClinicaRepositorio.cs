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
    public class AvaliacaoClinicaRepositorio : Repository<AvaliacaoClinica>, IAvaliacaoClinicaRepositorio
    {
        public AvaliacaoClinicaRepositorio(ContextoMarcaPlantao db) : base(db)
        {
        }

        public async Task<List<AvaliacaoClinica>> ObterPorPlantaoId(Guid plantaoId) 
        {
            return await Db.AvaliacaoClinicas.AsNoTracking().Where(x => x.PlantaoId == plantaoId).ToListAsync();
        }

        public async Task<List<AvaliacaoClinica>> ObterPorProfissionaisId(Guid profissionalId)
        {
            return await Db.AvaliacaoClinicas.AsNoTracking().Where(x => x.ProfissionalId == profissionalId).ToListAsync();
        }
    }
}
