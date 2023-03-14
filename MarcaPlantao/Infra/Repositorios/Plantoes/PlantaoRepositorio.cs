using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Infra.Contexto;
using MarcaPlantao.Infra.Repositorios.Ofertas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Plantoes
{
    public class PlantaoRepositorio : Repository<Plantao>, IPlantaoRepositorio
    {
        public PlantaoRepositorio(ContextoMarcaPlantao db) : base(db)
        {
        }

        public async Task<Plantao> ObterPlantaoProfissionalOfertaPorId(Guid Id)
        {
            return await Db.Plantoes.AsNoTracking()
                                    .Include(x => x.Profissional)
                                    .Include(x => x.Oferta)
                                    .Where(x => x.Id == Id)
                                    .FirstOrDefaultAsync();
        }

        public async Task<List<Plantao>> ObterTodasPlantaoProfissionalOferta()
        {
            return await Db.Plantoes.AsNoTracking()
                                    .Include(x => x.Profissional)
                                    .Include(x => x.Oferta)
                                    .ToListAsync();
        }
    }
}
