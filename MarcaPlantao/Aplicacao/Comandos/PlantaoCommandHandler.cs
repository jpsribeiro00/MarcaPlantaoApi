using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.PlantaoComandos;
using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Repositorios.Avaliacao;
using MarcaPlantao.Infra.Repositorios.Clinicas;
using MarcaPlantao.Infra.Repositorios.Ofertas;
using MarcaPlantao.Infra.Repositorios.Plantoes;
using MarcaPlantao.Infra.Repositorios.Profissionais;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos
{
    public class PlantaoCommandHandler :
        IRequestHandler<AtualizarPlantaoComando, bool>,
        IRequestHandler<RemoverPlantaoComando, bool>,
        IRequestHandler<AdicionarPlantaoComando, Entidade>, 
        IRequestHandler<AtualizarStatusPlantaoComando, bool>,
        IRequestHandler<EncerrarPlantaoComando, bool>
    {
        private readonly IMediatorHandler mediadorHandler;
        private readonly IPlantaoRepositorio plantaoRepositorio;
        private readonly IOfertaRepositorio ofertaRepositorio;
        private readonly IProfissionalRepositorio profissionalRepositorio;
        private readonly IAvaliacaoProfissionalRepositorio avaliacaoProfissionalRepositorio;
        private readonly IMapper mapper;

        public PlantaoCommandHandler(IMediatorHandler mediadorHandler, IPlantaoRepositorio plantaoRepositorio, IMapper mapper, IOfertaRepositorio ofertaRepositorio, IProfissionalRepositorio profissionalRepositorio, IAvaliacaoProfissionalRepositorio avaliacaoProfissionalRepositorio)
        {
            this.mediadorHandler = mediadorHandler;
            this.plantaoRepositorio = plantaoRepositorio;
            this.mapper = mapper;
            this.ofertaRepositorio = ofertaRepositorio;
            this.profissionalRepositorio = profissionalRepositorio;
            this.avaliacaoProfissionalRepositorio = avaliacaoProfissionalRepositorio;
        }

        public async Task<Entidade> Handle(AdicionarPlantaoComando request, CancellationToken cancellationToken)
        {
            Plantao plantaoAdicionado = new Plantao();

            try
            {
                if (!ValidarComando(request)) return plantaoAdicionado;

                var oferta = await ofertaRepositorio.ObterPorId(request.OfertaId);
                var profissional = await profissionalRepositorio.ObterPorId(request.ProfissionalId);

                if(oferta != null && profissional != null) 
                {
                    plantaoAdicionado.ProfissionalId = profissional.Id;
                    plantaoAdicionado.OfertaId = oferta.Id;
                    plantaoAdicionado.Status = StatusPlantao.NaoIniciado;
                    plantaoAdicionado.DataInicial = oferta.DataInicial;
                    plantaoAdicionado.DataFinal = oferta.DataFinal;
                    plantaoAdicionado.ValorTotal = oferta.Valor;
                    plantaoAdicionado.HoraExtra = oferta.ValorHoraExtra;
                    plantaoAdicionado.StatusPagamento = StatusPagamento.Pendente;
                    plantaoAdicionado.ClinicaId = oferta.ClinicaId;
                    plantaoAdicionado.DataPagamento = null;

                    return await plantaoRepositorio.AdicionarComRetornoDeObjeto(plantaoAdicionado);
                }

                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Não existe oferta ou profissional informados!"));
                return plantaoAdicionado;
            }
            catch (DominioException ex)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, ex.Message));
                return plantaoAdicionado;
            }
            catch (Exception ex)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, ex.Message));
                return plantaoAdicionado;
            }
        }

        public async Task<bool> Handle(AtualizarPlantaoComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var plantaoExiste = await plantaoRepositorio.ObterPorId(request.Id);

                if (plantaoExiste == null)
                {
                    await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Plantão informado não encontrado."));
                    return false;
                }

                plantaoExiste.Status = (StatusPlantao)request.Status;
                plantaoExiste.DataInicial = request.DataInicial;
                plantaoExiste.DataFinal = request.DataFinal;
                plantaoExiste.ValorTotal = request.ValorTotal;
                plantaoExiste.HoraExtra = request.HoraExtra;
                plantaoExiste.Desconto = request.Desconto;
                plantaoExiste.StatusPagamento = (StatusPagamento)request.StatusPagamento;
                plantaoExiste.DataPagamento = request.DataPagamento;
                plantaoExiste.Comprovante = request.Comprovante;
                plantaoExiste.DataCadastro = request.DataCadastro;

                await plantaoRepositorio.Atualizar(plantaoExiste);

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

        public async Task<bool> Handle(RemoverPlantaoComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                await plantaoRepositorio.Remover(request.Id);

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

        public async Task<bool> Handle(AtualizarStatusPlantaoComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var plantao = await plantaoRepositorio.ObterPorId(request.Id);

                if(plantao != null) 
                {
                    plantao.Status = (StatusPlantao)request.Status;

                    await plantaoRepositorio.Atualizar(plantao);

                    return true;
                }

                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Plantão informado não encontrado"));
                return false;
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

        public async Task<bool> Handle(EncerrarPlantaoComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var plantao = await plantaoRepositorio.ObterPorId(request.Id);

                if (plantao != null)
                {
                    plantao.Status = StatusPlantao.Finalizado;
                    plantao.Comprovante = request.Comprovante;

                    await plantaoRepositorio.Atualizar(plantao);

                    var avaliacaoProfissional = new AvaliacaoProfissional();
                    avaliacaoProfissional.Nota = request.Nota;
                    avaliacaoProfissional.Descricao = request.Descricao;
                    avaliacaoProfissional.DataAvaliacao = request.DataAvaliacao;
                    avaliacaoProfissional.ClinicaId = request.ClinicaId;
                    avaliacaoProfissional.ProfissionalId = request.ProfissionalId;
                    avaliacaoProfissional.PlantaoId = plantao.Id;

                    await avaliacaoProfissionalRepositorio.Adicionar(avaliacaoProfissional);

                    return true;
                }

                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Plantão informado não encontrado"));
                return false;
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

        private bool ValidarComando(ComandoAdicionar mensagem)
        {
            if (mensagem.EhValido()) return true;

            foreach (var error in mensagem.ResultadoValidacao.Errors)
            {
                mediadorHandler.PublicarNotificacao(new NotificacaoDominio(mensagem.Tipo, error.ErrorMessage));
            }

            return false;
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
