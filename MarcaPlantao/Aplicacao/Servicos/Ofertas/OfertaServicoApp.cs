using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.EnderecoComandos;
using MarcaPlantao.Aplicacao.Comandos.OfertaComandos;
using MarcaPlantao.Aplicacao.Consultas.Enderecos;
using MarcaPlantao.Aplicacao.Consultas.Ofertas;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Ofertas
{
    public class OfertaServicoApp : IOfertaServicoApp
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediador;
        private readonly IOfertaConsultaApp ofertaConsultaApp;

        public OfertaServicoApp(IMapper mapper, IMediatorHandler mediador, IOfertaConsultaApp ofertaConsultaApp)
        {
            this.mapper = mapper;
            this.mediador = mediador;
            this.ofertaConsultaApp = ofertaConsultaApp;
        }

        public async Task<bool> AdicionarAsync(OfertaDados OfertaDados)
        {
            var adicionarComando = mapper.Map<AdicionarOfertaComando>(OfertaDados);
            return await mediador.EnviarComando(adicionarComando);
        }

        public async Task<bool> AtualizarAsync(OfertaDados OfertaDados)
        {
            var atualizarComando = mapper.Map<AtualizarOfertaComando>(OfertaDados);
            return await mediador.EnviarComando(atualizarComando);
        }

        public async Task<OfertaDados> ObterPorId(Guid id)
        {
            return await ofertaConsultaApp.ObterPorId(id);
        }

        public async Task<List<OfertaDados>> ObterTodos()
        {
            return await ofertaConsultaApp.ObterTodos();
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var oferta = new OfertaDados();
            oferta.Id = id;

            var removerComando = mapper.Map<RemoverOfertaComando>(oferta);
            return await mediador.EnviarComando(removerComando);
        }
    }
}
