using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.PlantaoComandos;
using MarcaPlantao.Aplicacao.Consultas.Plantoes;
using MarcaPlantao.Aplicacao.Dados.Plantoes;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Plantoes
{
    public class PlantaoServicoApp : IPlantaoServicoApp
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediador;
        private readonly IPlantaoConsultaApp plantaoConsultaApp;

        public PlantaoServicoApp(IMapper mapper, IMediatorHandler mediador, IPlantaoConsultaApp plantaoConsultaApp)
        {
            this.mapper = mapper;
            this.mediador = mediador;
            this.plantaoConsultaApp = plantaoConsultaApp;
        }

        public async Task<bool> AdicionarAsync(GerarPlantaoDados plantao)
        {
            var adicionarComando = mapper.Map<AdicionarPlantaoComando>(plantao);
            return await mediador.EnviarComando(adicionarComando);
        }

        public async Task<bool> AtualizarAsync(PlantaoDados plantao)
        {
            var atualizarComando = mapper.Map<AtualizarPlantaoComando>(plantao);
            return await mediador.EnviarComando(atualizarComando);
        }

        public async Task<PlantaoDados> ObterPorId(Guid id)
        {
            return await plantaoConsultaApp.ObterPorId(id);
        }

        public async Task<List<PlantaoDados>> ObterTodos()
        {
            return await plantaoConsultaApp.ObterTodos();
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var profissional = new PlantaoDados();
            profissional.Id = id;

            var adicionarComando = mapper.Map<RemoverPlantaoComando>(profissional);
            return await mediador.EnviarComando(adicionarComando);
        }
    }
}
