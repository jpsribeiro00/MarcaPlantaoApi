using MarcaPlantao.Aplicacao.Consultas.EventosClinica;
using MarcaPlantao.Aplicacao.Consultas.EventosProfissionais;
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
        private readonly IEventoClinicaConsultaApp eventoConsultaApp;
        private readonly IEventoProfissionalConsultaApp eventoProfissionalConsultaApp;

        public ConsultaController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IEventoClinicaConsultaApp eventoConsultaApp, IEventoProfissionalConsultaApp eventoProfissionalConsultaApp) : base(notifications, mediator)
        {
            this.eventoConsultaApp = eventoConsultaApp;
            this.eventoProfissionalConsultaApp = eventoProfissionalConsultaApp;
        }

        [HttpGet("ObterEventosPorClinica")]
        public async Task<IActionResult> ObterEventorsPorClinica(Guid Id)
        {
            var resultado = await eventoConsultaApp.BuscarEventosClinica(Id);

            return Response(resultado);
        }

        [HttpGet("ObterEventosPorProfissional")]
        public async Task<IActionResult> ObterEventosPorProfissional(Guid Id)
        {
            var resultado = await eventoProfissionalConsultaApp.BuscarEventosProfissional(Id);

            return Response(resultado);
        }
    }
}
