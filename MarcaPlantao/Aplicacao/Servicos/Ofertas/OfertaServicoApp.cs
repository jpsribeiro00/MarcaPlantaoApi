using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.EnderecoComandos;
using MarcaPlantao.Aplicacao.Comandos.OfertaComandos;
using MarcaPlantao.Aplicacao.Consultas.Enderecos;
using MarcaPlantao.Aplicacao.Consultas.Ofertas;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Dominio.Ofertas;
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

        public async Task<ObterOfertaDados> AdicionarAsync(AdicionarOfertaDados OfertaDados)
        {
            var adicionarComando = mapper.Map<AdicionarOfertaComando>(OfertaDados);
            return mapper.Map<ObterOfertaDados>((Oferta)await mediador.EnviarComandoAdicionar(adicionarComando));
        }

        public async Task<bool> AtualizarAsync(AtualizarOfertaDados OfertaDados)
        {
            var atualizarComando = mapper.Map<AtualizarOfertaComando>(OfertaDados);
            return await mediador.EnviarComando(atualizarComando);
        }

        public async Task<ObterOfertaDados> ObterPorId(Guid id)
        {
            return await ofertaConsultaApp.ObterPorId(id);
        }

        public async Task<List<ObterOfertaDados>> ObterTodos()
        {
            return await ofertaConsultaApp.ObterTodos();
        }

        public async Task<List<ListaOfertasAbertasProfissional>> ObterOfertasAbertasParaProfissional(Guid ProfissionalId, DateTime? dataInicio, DateTime? dataFinal, double? valorInicial, double? valorFinal, string? turno)
        {
            return await ofertaConsultaApp.ObterOfertasAbertasParaProfissional(ProfissionalId, dataInicio, dataFinal, valorInicial, valorFinal, turno);
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var oferta = new OfertaDados();
            oferta.Id = id;

            var removerComando = mapper.Map<RemoverOfertaComando>(oferta);
            return await mediador.EnviarComando(removerComando);
        }

        public async Task<bool> AdicionarProfissionalOfertaAsync(Guid profissionalId, Guid ofertaId)
        {
            return await mediador.EnviarComando(new AdicionarProfissionalOfertaComando(profissionalId, ofertaId));
        }

        public async Task<bool> RemoverProfissionalOfertaAsync(Guid profissionalId, Guid ofertaId)
        {
            return await mediador.EnviarComando(new RemoverProfissionalOfertaComando(profissionalId, ofertaId));
        }
    }
}
