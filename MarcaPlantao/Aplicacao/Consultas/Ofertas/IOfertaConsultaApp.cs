using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Ofertas
{
    public interface IOfertaConsultaApp
    {
        Task<OfertaDados> ObterPorId(Guid id);

        Task<List<OfertaDados>> ObterTodos();
    }
}
