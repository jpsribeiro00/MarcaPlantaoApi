using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Especializacoes
{
    public interface IEspecializacaoConsultaApp
    {
        Task<EspecializacaoDados> ObterPorId(Guid id);

        Task<List<EspecializacaoDados>> ObterTodos();
    }
}
