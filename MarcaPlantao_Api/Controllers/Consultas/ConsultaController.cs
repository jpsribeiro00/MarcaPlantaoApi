using MarcaPlantao.Aplicacao.Consultas.Eventos;
using MarcaPlantao.Aplicacao.Servicos.Clinicas;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Servico.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcaPlantao_Api.Controllers.Consultas
{
    [ApiController]
    [AllowAnonymous]
    public class ConsultaController : ApiControllerBase
    {
        private readonly IEventoConsultaApp eventoConsultaApp;

        public ConsultaController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IEventoConsultaApp eventoConsultaApp) : base(notifications, mediator)
        {
            this.eventoConsultaApp = eventoConsultaApp;
        }

        [HttpGet("ObterEventosPorClinica")]
        public async Task<IActionResult> ObterEventorsPorClinica(Guid Id)
        {
            var resultado = await eventoConsultaApp.BuscarEventosClinica(Id);

            return Response(resultado);
        }
    }
}
