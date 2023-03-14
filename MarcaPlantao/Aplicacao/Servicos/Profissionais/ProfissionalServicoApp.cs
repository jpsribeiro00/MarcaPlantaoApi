using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.ProfissionalComandos;
using MarcaPlantao.Aplicacao.Consultas.Profissionais;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Profissionais
{
    public class ProfissionalServicoApp : IProfissionalServicoApp
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediador;
        private readonly IProfissionalConsultaApp profissionalConsultaApp;

        public ProfissionalServicoApp(IMapper mapper, IMediatorHandler mediador, IProfissionalConsultaApp profissionalConsultaApp)
        {
            this.mapper = mapper;
            this.mediador = mediador;
            this.profissionalConsultaApp = profissionalConsultaApp;
        }

        public async Task<bool> AdicionarAsync(ProfissionalDados profissional)
        {
            var adicionarComando = mapper.Map<AdicionarProfissionalComando>(profissional);
            return await mediador.EnviarComando(adicionarComando);
        }

        public async Task<bool> AtualizarAsync(AtualizarProfissionalDados profissional)
        {
            var atualizarComando = mapper.Map<AtualizarProfissionalComando>(profissional);
            return await mediador.EnviarComando(atualizarComando);
        }

        public async Task<ObterProfissionalDados> ObterPorId(Guid id)
        {
            return await profissionalConsultaApp.ObterPorId(id);
        }

        public async Task<List<ObterProfissionalDados>> ObterTodos()
        {
            return await profissionalConsultaApp.ObterTodos();
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var profissional = new ProfissionalDados();
            profissional.Id = id;

            var adicionarComando = mapper.Map<RemoverProfissionalComando>(profissional);
            return await mediador.EnviarComando(adicionarComando);
        }
    }
}
