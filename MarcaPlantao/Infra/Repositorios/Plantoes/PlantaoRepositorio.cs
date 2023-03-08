using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Infra.Contexto;
using MarcaPlantao.Infra.Repositorios.Ofertas;
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
    }
}
