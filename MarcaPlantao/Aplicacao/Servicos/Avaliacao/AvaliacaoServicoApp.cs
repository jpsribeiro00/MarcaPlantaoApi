using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.AvaliacaoComandos;
using MarcaPlantao.Aplicacao.Consultas.AvaliacaoPlantao;
using MarcaPlantao.Aplicacao.Dados.Avaliacoes;
using MarcaPlantao.Aplicacao.Dados.Clinicas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Avaliacao
{
    public class AvaliacaoServicoApp : IAvaliacaoServicoApp
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediador;
        private readonly IAvaliacaoPlantaoConsultaApp avaliacaoPlantaoConsultaApp;

        public AvaliacaoServicoApp(IMapper mapper, IMediatorHandler mediador, IAvaliacaoPlantaoConsultaApp avaliacaoPlantaoConsultaApp)
        {
            this.mapper = mapper;
            this.mediador = mediador;
            this.avaliacaoPlantaoConsultaApp = avaliacaoPlantaoConsultaApp;
        }

        public async Task<bool> AdicionarAvaliacaoProfissionalPlantao(AdicionarAvaliacaoProfissionalPlantaoDados adicionarAvaliacaoProfissionalPlantaoDados)
        {
            var adicionarComando = mapper.Map<AdicionarAvaliacaoProfissionalClinicaComando>(adicionarAvaliacaoProfissionalPlantaoDados);
            return await mediador.EnviarComando(adicionarComando);
        }

        public async Task<object> ObterAvaliacaoPlantao(Guid plantaoId)
        {
           return await avaliacaoPlantaoConsultaApp.ObterAvaliacaoPlantao(plantaoId);
        }

        public async Task<List<ObterAvaliacaoClinicaParaProfissional>> ObterAvaliacaoProfissional(Guid profissionalId)
        {
            return await avaliacaoPlantaoConsultaApp.ObterAvaliacaoProfissionais(profissionalId);
        }
    }
}
