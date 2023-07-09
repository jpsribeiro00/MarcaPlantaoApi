using MarcaPlantao.Aplicacao.Dados.Avaliacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.AvaliacaoPlantao
{
    public interface IAvaliacaoPlantaoConsultaApp
    {
        Task<object> ObterAvaliacaoPlantao(Guid plantaoId);

        Task<List<AvaliacaoClinicaSimplificadoDados>> ObterAvaliacaoProfissionais(Guid profissionalId);
    }
}
