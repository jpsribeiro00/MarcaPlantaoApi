using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Ofertas
{
    public class OfertaRepositorio : Repository<Oferta>, IOfertaRepositorio
    {
        public OfertaRepositorio(ContextoMarcaPlantao db) : base(db) { }
    }
}
