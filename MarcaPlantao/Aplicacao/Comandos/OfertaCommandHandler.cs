using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.OfertaComandos;
using MarcaPlantao.Infra.Repositorios.Ofertas;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Infraestrutura.Mensagens;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Repositorios.Profissionais;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Infra.Repositorios.Especializacoes;

namespace MarcaPlantao.Aplicacao.Comandos
{
    public class OfertaCommandHandler :
        IRequestHandler<AdicionarOfertaComando, bool>,
        IRequestHandler<AtualizarOfertaComando, bool>,
        IRequestHandler<RemoverOfertaComando, bool>

    {
        private readonly IMediatorHandler mediadorHandler;
        private readonly IOfertaRepositorio ofertaRepositorio;
        private readonly IEspecializacaoRepositorio especializacaoRepositorio;
        private readonly IMapper mapper;

        public OfertaCommandHandler(IMediatorHandler mediadorHandler, IOfertaRepositorio ofertaRepositorio, IEspecializacaoRepositorio especializacaoRepositorio, IMapper mapper)
        {
            this.mediadorHandler = mediadorHandler;
            this.ofertaRepositorio = ofertaRepositorio;
            this.especializacaoRepositorio = especializacaoRepositorio;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(AdicionarOfertaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var oferta = new Oferta();
                oferta.Descricao = request.Descricao;
                oferta.Pagamento = (Pagamento)request.Pagamento;
                oferta.Turno = request.Turno;
                oferta.Valor = request.Valor;
                oferta.ValorHoraExtra = request.ValorHoraExtra;
                oferta.DataCadastro = request.DataCadastro;
                oferta.DataInicial = request.DataInicial;
                oferta.DataFinal = request.DataFinal;
                oferta.Titulo = request.Titulo;
                oferta.Profissionais = mapper.Map<ICollection<Profissional>>(request.Profissionais);
                oferta.Especializacoes = await BuscarEspecializacoes(request.Especializacoes);
                oferta.ClinicaId = request.Clinica.Id;

                await ofertaRepositorio.Adicionar(oferta);

                return true;

            }
            catch (DominioException ex)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, ex.Message));
                return false;
            }
            catch (Exception ex)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, ex.Message));
                return false;
            }
        }

        public async Task<bool> Handle(AtualizarOfertaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var oferta = new Oferta();
                oferta.Id = request.Id;
                oferta.Descricao = request.Descricao;
                oferta.Pagamento = (Pagamento)request.Pagamento;
                oferta.Turno = request.Turno;
                oferta.Valor = request.Valor;
                oferta.ValorHoraExtra = request.ValorHoraExtra;
                oferta.DataCadastro = request.DataCadastro;
                oferta.DataInicial = request.DataInicial;
                oferta.DataFinal = request.DataFinal;
                oferta.Titulo = request.Titulo;
                oferta.Profissionais = mapper.Map<ICollection<Profissional>>(request.Profissionais);
                oferta.ClinicaId = request.Clinica.Id;

                await ofertaRepositorio.Atualizar(oferta);

                return true;

            }
            catch (DominioException ex)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, ex.Message));
                return false;
            }
            catch (Exception ex)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, ex.Message));
                return false;
            }
        }

        public async Task<bool> Handle(RemoverOfertaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                await ofertaRepositorio.Remover(request.Id);

                return true;

            }
            catch (DominioException ex)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, ex.Message));
                return false;
            }
            catch (Exception ex)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, ex.Message));
                return false;
            }
        }

        private async Task<List<Especializacao>> BuscarEspecializacoes(List<EspecializacaoDados> especializacaoDados)
        {
            var Especializacoes = new List<Especializacao>();

            foreach (Especializacao item in mapper.Map<ICollection<Especializacao>>(especializacaoDados))
            {
                var especializacaoBanco = await especializacaoRepositorio.ObterPorId(item.Id);

                if (especializacaoBanco != null)
                {
                    Especializacoes.Add(especializacaoBanco);
                }
            }

            return Especializacoes;
        }

        private bool ValidarComando(Comando mensagem)
        {
            if (mensagem.EhValido()) return true;

            foreach (var error in mensagem.ResultadoValidacao.Errors)
            {
                mediadorHandler.PublicarNotificacao(new NotificacaoDominio(mensagem.Tipo, error.ErrorMessage));
            }

            return false;
        }
    }
}
