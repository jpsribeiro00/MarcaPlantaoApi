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
        IRequestHandler<RemoverOfertaComando, bool>,
        IRequestHandler<AdicionarProfissionalOfertaComando, bool>,
        IRequestHandler<RemoverProfissionalOfertaComando, bool>

    {
        private readonly IMediatorHandler mediadorHandler;
        private readonly IOfertaRepositorio ofertaRepositorio;
        private readonly IEspecializacaoRepositorio especializacaoRepositorio;
        private readonly IProfissionalRepositorio profissionalRepositorio;
        private readonly IMapper mapper;

        public OfertaCommandHandler(IMediatorHandler mediadorHandler, IOfertaRepositorio ofertaRepositorio,
            IEspecializacaoRepositorio especializacaoRepositorio, IProfissionalRepositorio profissionalRepositorio, IMapper mapper)
        {
            this.mediadorHandler = mediadorHandler;
            this.ofertaRepositorio = ofertaRepositorio;
            this.especializacaoRepositorio = especializacaoRepositorio;
            this.profissionalRepositorio = profissionalRepositorio;
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
                oferta.Especializacoes = await BuscarEspecializacoes(request.Especializacoes);
                oferta.ClinicaId = request.ClinicaId;

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

                var ofertaExiste = await ofertaRepositorio.ObterPorId(request.Id);

                if(ofertaExiste == null) 
                {
                    await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Oferta informada não encontrada."));
                    return false;
                }

                ofertaExiste.Descricao = request.Descricao;
                ofertaExiste.Pagamento = (Pagamento)request.Pagamento;
                ofertaExiste.Turno = request.Turno;
                ofertaExiste.Valor = request.Valor;
                ofertaExiste.ValorHoraExtra = request.ValorHoraExtra;
                ofertaExiste.DataCadastro = request.DataCadastro;
                ofertaExiste.DataInicial = request.DataInicial;
                ofertaExiste.DataFinal = request.DataFinal;
                ofertaExiste.Titulo = request.Titulo;

                await ofertaRepositorio.Atualizar(ofertaExiste);

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

        public async Task<bool> Handle(AdicionarProfissionalOfertaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var oferta = await ofertaRepositorio.ObterOfertaModificarProfissionalPorId(request.OfertaId);

                if(oferta != null) 
                {
                    var profissional = await profissionalRepositorio.ObterPorId(request.ProfissionalId);

                    if(profissional != null) 
                    {
                        oferta.Profissionais.Add(profissional);

                        await ofertaRepositorio.SalvarMudancas();

                        return true;
                    }
                    else 
                    {
                        await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Profissional informado não existe"));
                        return false;
                    }
                }
                else 
                {
                    await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Oferta informada não existe"));
                    return false;
                }

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

        public async Task<bool> Handle(RemoverProfissionalOfertaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var oferta = await ofertaRepositorio.ObterOfertaModificarProfissionalPorId(request.OfertaId);

                if (oferta != null)
                {
                    oferta.Profissionais.Remove(oferta.Profissionais.Where(x => x.Id == request.ProfissionalId).First());

                    await ofertaRepositorio.SalvarMudancas();

                    return true;
                }
                else
                {
                    await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Oferta informada não existe"));
                    return false;
                }

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

        private async Task<List<Especializacao>> BuscarEspecializacoes(List<Guid> especializacoesId)
        {
            var Especializacoes = new List<Especializacao>();

            foreach (Guid item in especializacoesId)
            {
                var especializacaoBanco = await especializacaoRepositorio.ObterPorId(item);

                if (especializacaoBanco != null)
                {
                    Especializacoes.Add(especializacaoBanco);
                }
            }

            return Especializacoes;
        }

        private async Task<List<Profissional>> BuscarProfissionais(List<Guid> profissionaisId)
        {
            var profissionais = new List<Profissional>();

            foreach (Guid item in profissionaisId)
            {
                var profissionalBanco = await profissionalRepositorio.ObterPorId(item);

                if (profissionalBanco != null)
                {
                    profissionais.Add(profissionalBanco);
                }
            }

            return profissionais;
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
