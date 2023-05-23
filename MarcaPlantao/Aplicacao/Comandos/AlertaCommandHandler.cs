using MarcaPlantao.Aplicacao.Comandos.AlertaComandos;
using MarcaPlantao.Infra.Repositorios.Alertas;
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
    public class AlertaCommandHandler :
        IRequestHandler<RemoverAlertaComando, bool>
    {
        private readonly IMediatorHandler mediadorHandler;
        private readonly IAlertaRepositorio alertaRepositorio;

        public AlertaCommandHandler(IMediatorHandler mediadorHandler, IAlertaRepositorio alertaRepositorio)
        {
            this.mediadorHandler = mediadorHandler;
            this.alertaRepositorio = alertaRepositorio;
        }

        public async Task<bool> Handle(RemoverAlertaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                await alertaRepositorio.Remover(request.Id);

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
