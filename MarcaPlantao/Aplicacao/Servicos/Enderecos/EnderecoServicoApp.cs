using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.EnderecoComandos;
using MarcaPlantao.Aplicacao.Comandos.ProfissionalComandos;
using MarcaPlantao.Aplicacao.Consultas.Enderecos;
using MarcaPlantao.Aplicacao.Consultas.Profissionais;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Enderecos
{
    public class EnderecoServicoApp : IEnderecoServicoApp
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediador;
        private readonly IEnderecoConsultaApp enderecoConsultaApp;

        public EnderecoServicoApp(IMapper mapper, IMediatorHandler mediador, IEnderecoConsultaApp enderecoConsultaApp)
        {
            this.mapper = mapper;
            this.mediador = mediador;
            this.enderecoConsultaApp = enderecoConsultaApp;
        }

        public async Task<bool> AdicionarAsync(EnderecoDados enderecoDados)
        {
            var adicionarComando = mapper.Map<AdicionarEnderecoComando>(enderecoDados);
            return await mediador.EnviarComando(adicionarComando);
        }

        public async Task<bool> AtualizarAsync(EnderecoDados enderecoDados)
        {
            var atualizarComando = mapper.Map<AdicionarEnderecoComando>(enderecoDados);
            return await mediador.EnviarComando(atualizarComando);
        }

        public async Task<EnderecoDados> ObterPorId(Guid id)
        {
            return await enderecoConsultaApp.ObterPorId(id);
        }

        public async Task<List<EnderecoDados>> ObterTodos()
        {
            return await enderecoConsultaApp.ObterTodos();
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var endereco = new EnderecoDados();
            endereco.Id = id;

            var adicionarComando = mapper.Map<RemoverEnderecoComando>(endereco);
            return await mediador.EnviarComando(adicionarComando);
        }
    }
}
