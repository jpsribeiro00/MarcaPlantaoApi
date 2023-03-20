using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.ClinicaComandos;
using MarcaPlantao.Aplicacao.Comandos.EnderecoComandos;
using MarcaPlantao.Aplicacao.Consultas.Clinicas;
using MarcaPlantao.Aplicacao.Consultas.Enderecos;
using MarcaPlantao.Aplicacao.Dados.Avaliacoes;
using MarcaPlantao.Aplicacao.Dados.Clinicas;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Clinicas
{
    public class ClinicaServicoApp : IClinicaServicoApp
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediador;
        private readonly IClinicaConsultaApp clinicaConsultaApp;

        public ClinicaServicoApp(IMapper mapper, IMediatorHandler mediador, IClinicaConsultaApp clinicaConsultaApp)
        {
            this.mapper = mapper;
            this.mediador = mediador;
            this.clinicaConsultaApp = clinicaConsultaApp;
        }

        public async Task<bool> AdicionarAsync(ClinicaDados clinicaDados)
        {
            var adicionarComando = mapper.Map<AdicionarClinicaComando>(clinicaDados);
            return await mediador.EnviarComando(adicionarComando);
        }

        public async Task<bool> AtualizarAsync(ClinicaArquivoDados clinicaDados)
        {
            var atualizarComando = mapper.Map<AtualizarClinicaComando>(mapper.Map<ClinicaDados>(clinicaDados));
            return await mediador.EnviarComando(atualizarComando);
        }

        public async Task<ClinicaDados> ObterPorId(Guid id)
        {
            return await clinicaConsultaApp.ObterPorId(id);
        }

        public async Task<List<ClinicaDados>> ObterTodos()
        {
            return await clinicaConsultaApp.ObterTodos();
        }

        public async Task<bool> AdicionarAvaliacaoAsync(AdicionarAvaliacaoClinicaDados clinicaDados)
        {
            var atualizarComando = mapper.Map<AdicionarAvaliacaoClinicaComando>(mapper.Map<AdicionarAvaliacaoClinicaDados>(clinicaDados));
            return await mediador.EnviarComando(atualizarComando);
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var clinica = new ClinicaDados();
            clinica.Id = id;

            var removerComando = mapper.Map<RemoverClinicaComando>(clinica);
            return await mediador.EnviarComando(removerComando);
        }
    }
}
