using MarcaPlantao.Aplicacao.Dados.Avaliacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Avaliacao
{
    public interface IAvaliacaoServicoApp
    {
        Task<List<ObterAvaliacaoClinicaParaProfissional>> ObterAvaliacaoProfissional(Guid profissionalId);

        Task<object> ObterAvaliacaoPlantao(Guid plantaoId);

        Task<bool> AdicionarAvaliacaoProfissionalPlantao(AdicionarAvaliacaoProfissionalPlantaoDados adicionarAvaliacaoProfissionalPlantaoDados);
    }
}
