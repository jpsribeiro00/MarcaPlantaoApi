using MarcaPlantao.Aplicacao.Dados.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Ofertas
{
    public interface IOfertaServicoApp
    {
        Task<bool> AdicionarAsync(OfertaDados OfertaDados);

        Task<bool> AtualizarAsync(OfertaDados OfertaDados);

        Task<bool> RemoverAsync(Guid id);

        Task<OfertaDados> ObterPorId(Guid id);

        Task<List<OfertaDados>> ObterTodos();
    }
}
