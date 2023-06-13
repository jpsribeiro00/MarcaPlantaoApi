using MarcaPlantao.Aplicacao.Servicos.Alertas;
using MarcaPlantao.Aplicacao.Servicos.Clinicas;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Servico.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcaPlantao_Api.Controllers.Alertas
{
    [ApiController]
    [AllowAnonymous]
    public class AlertaController : ApiControllerBase
    {
        private readonly IAlertaServicoApp alertaServicoApp;

        public AlertaController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IAlertaServicoApp alertaServicoApp) : base(notifications, mediator)
        {
            this.alertaServicoApp = alertaServicoApp;
        }

        [HttpGet("ObterAlertaUsuario")]
        public async Task<IActionResult> ObterPorUsuario(Guid profissionalId)
        {
            var resultado = await alertaServicoApp.ObterPorUsuario(profissionalId);

            return Response(resultado);
        }

        [HttpGet("ObterAlertaClinica")]
        public async Task<IActionResult> ObterPorClinica(Guid clinicaId)
        {
            var resultado = await alertaServicoApp.ObterPorClinica(clinicaId);

            return Response(resultado);
        }

        [HttpDelete("RemoverAlerta")]
        public async Task<IActionResult> RemoverAlerta(Guid Id)
        {
            var resultado = await alertaServicoApp.RemoverAsync(Id);

            return Response(resultado);
        }
    }
}
