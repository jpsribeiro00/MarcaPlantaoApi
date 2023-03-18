using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.PlantaoComandos;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Dominio.Profissionais;
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
        IRequestHandler<AdicionarPlantaoComando, bool>, 
        IRequestHandler<AtualizarStatusPlantaoComando, bool>
    {
        private readonly IMediatorHandler mediadorHandler;
        private readonly IPlantaoRepositorio plantaoRepositorio;
        private readonly IOfertaRepositorio ofertaRepositorio;
        private readonly IProfissionalRepositorio profissionalRepositorio;
        private readonly IMapper mapper;

        public PlantaoCommandHandler(IMediatorHandler mediadorHandler, IPlantaoRepositorio plantaoRepositorio, IMapper mapper, IOfertaRepositorio ofertaRepositorio, IProfissionalRepositorio profissionalRepositorio)
        {
            this.mediadorHandler = mediadorHandler;
            this.plantaoRepositorio = plantaoRepositorio;
            this.mapper = mapper;
            this.ofertaRepositorio = ofertaRepositorio;
            this.profissionalRepositorio = profissionalRepositorio;
        }

        public async Task<bool> Handle(AdicionarPlantaoComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var oferta = await ofertaRepositorio.ObterPorId(request.OfertaId);
                var profissional = await profissionalRepositorio.ObterPorId(request.ProfissionalId);

                if(oferta != null && profissional != null) 
                {
                    var plantao = new Plantao();
                    plantao.ProfissionalId = profissional.Id;
                    plantao.OfertaId = oferta.Id;
                    plantao.Status = StatusPlantao.NaoIniciado;
                    plantao.DataInicial = oferta.DataInicial;
                    plantao.DataFinal = oferta.DataFinal;
                    plantao.ValorTotal = oferta.Valor;
                    plantao.HoraExtra = oferta.ValorHoraExtra;
                    plantao.StatusPagamento = StatusPagamento.Pendente;
                    plantao.ClinicaId = oferta.ClinicaId;
                    plantao.DataPagamento = null;

                    await plantaoRepositorio.Adicionar(plantao);

                    return true;
                }

                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Não existe oferta ou profissional informados!"));
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
