using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.PlantaoComandos;
using MarcaPlantao.Dominio.Alertas;
using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Repositorios.Alertas;
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
using Newtonsoft.Json;
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
        private readonly IAvaliacaoClinicaRepositorio avaliacaoClinicaRepositorio;
        private readonly IAlertaRepositorio alertaRepositorio;
        private readonly IMapper mapper;

        public PlantaoCommandHandler(IMediatorHandler mediadorHandler, IPlantaoRepositorio plantaoRepositorio,
            IMapper mapper, IOfertaRepositorio ofertaRepositorio, IProfissionalRepositorio profissionalRepositorio,
            IAvaliacaoClinicaRepositorio avaliacaoClinicaRepositorio, IAlertaRepositorio alertaRepositorio)
        {
            this.mediadorHandler = mediadorHandler;
            this.plantaoRepositorio = plantaoRepositorio;
            this.mapper = mapper;
            this.ofertaRepositorio = ofertaRepositorio;
            this.profissionalRepositorio = profissionalRepositorio;
            this.avaliacaoClinicaRepositorio = avaliacaoClinicaRepositorio;
            this.alertaRepositorio = alertaRepositorio;
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
                    plantaoAdicionado.StatusPagamento = StatusPagamento.Pendente;
                    plantaoAdicionado.ClinicaId = oferta.ClinicaId;
                    plantaoAdicionado.DataPagamento = null;

                    var plantaoRetorno = await plantaoRepositorio.AdicionarComRetornoDeObjeto(plantaoAdicionado);

                    Alerta alerta = new Alerta();
                    alerta.Componente = "PlantaoProfissional";
                    alerta.UserId = profissional.UserId;
                    alerta.TipoMensagem = "Informacao";
                    alerta.Mensagem = "Você foi escolhido para o plantão " + oferta.Titulo;
                    alerta.Data = JsonConvert.SerializeObject(new { id = plantaoRetorno.Id });

                    await alertaRepositorio.Adicionar(alerta);

                    return plantaoRetorno;
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

                var plantaoExiste = await plantaoRepositorio.ObterPlantaoProfissionalOfertaPorId(request.Id);

                if (plantaoExiste == null)
                {
                    await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Plantão informado não encontrado."));
                    return false;
                }

                var profissional = await profissionalRepositorio.ObterPorId(plantaoExiste.ProfissionalId);

                if (profissional == null)
                {
                    await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Profissional informado não encontrado."));
                    return false;
                }

                await plantaoRepositorio.Remover(request.Id);

                Alerta alerta = new Alerta();
                alerta.UserId = profissional.UserId;
                alerta.TipoMensagem = "Alerta";
                alerta.Mensagem = "Plantão da data" + plantaoExiste.DataInicial + " foi cancelado.";

                await alertaRepositorio.Adicionar(alerta);

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
                    plantao.DataFinal = request.DataFinal;
                    plantao.DataPagamento = request.DataFinal;
                    plantao.ValorTotal = request.ValorTotal;
                    plantao.HoraExtra = request.HoraExtra;
                    plantao.Desconto = request.Desconto;
                    plantao.StatusPagamento = StatusPagamento.Efetuado;

                    await plantaoRepositorio.Atualizar(plantao);

                    var avaliacaoClinica = new AvaliacaoClinica();
                    avaliacaoClinica.Nota = request.Nota;
                    avaliacaoClinica.Descricao = request.Descricao;
                    avaliacaoClinica.DataAvaliacao = request.DataAvaliacao;
                    avaliacaoClinica.ClinicaId = request.ClinicaId;
                    avaliacaoClinica.ProfissionalId = request.ProfissionalId;
                    avaliacaoClinica.PlantaoId = plantao.Id;

                    await avaliacaoClinicaRepositorio.Adicionar(avaliacaoClinica);

                    var profissional = await profissionalRepositorio.ObterPorId(plantao.ProfissionalId);

                    if (profissional == null)
                    {
                        await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Profissional informado não encontrado."));
                        return false;
                    }

                    Alerta alerta = new Alerta();
                    alerta.Componente = "PlantaoProfissional";
                    alerta.UserId = profissional.UserId;
                    alerta.TipoMensagem = "Informacao";
                    alerta.Mensagem = "Plantão da data " + plantao.DataInicial + " foi finalizado.";
                    alerta.Data = JsonConvert.SerializeObject(new { id = plantao.Id });

                    await alertaRepositorio.Adicionar(alerta);

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
