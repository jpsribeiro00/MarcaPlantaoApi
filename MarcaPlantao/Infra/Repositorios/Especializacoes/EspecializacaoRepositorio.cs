using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Infra.Contexto;
using MarcaPlantao.Infra.Repositorios.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Especializacoes
{
    public class EspecializacaoRepositorio : Repository<Especializacao>, IEspecializacaoRepositorio
    {
        public EspecializacaoRepositorio(ContextoMarcaPlantao db) : base(db)
        {
        }
    }
}
