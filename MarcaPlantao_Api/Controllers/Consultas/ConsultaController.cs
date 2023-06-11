using MarcaPlantao.Aplicacao.Consultas.EventosClinica;
using MarcaPlantao.Aplicacao.Consultas.EventosProfissionais;
using MarcaPlantao.Aplicacao.Servicos.Clinicas;
using MarcaPlantao.Infra.Repositorios.Consultas.PlantaoMeses;
using MarcaPlantao.Infra.Repositorios.Consultas.ValorDias;
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
        private readonly IPlantaoMesRepositorio plantaoMesRepositorio;
        private readonly IValorDiaRepositorio valorDiaRepositorio;

        public ConsultaController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IEventoClinicaConsultaApp eventoConsultaApp, IEventoProfissionalConsultaApp eventoProfissionalConsultaApp,
            IPlantaoMesRepositorio plantaoMesRepositorio, IValorDiaRepositorio valorDiaRepositorio) : base(notifications, mediator)
        {
            this.eventoConsultaApp = eventoConsultaApp;
            this.eventoProfissionalConsultaApp = eventoProfissionalConsultaApp;
            this.plantaoMesRepositorio = plantaoMesRepositorio;
            this.valorDiaRepositorio = valorDiaRepositorio;
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

        [HttpGet("ObterPlantaoMesClinica")]
        public async Task<IActionResult> ObterPlantaoMesClinica(Guid Id)
        {
            var resultado = await plantaoMesRepositorio.ObterIndicadorPlantaoMes(Id);

            return Response(resultado);
        }

        [HttpGet("ObterValorDiaClinica")]
        public async Task<IActionResult> ObterValorDiaClinica(Guid Id)
        {
            var resultado = await valorDiaRepositorio.ObterIndicadorValorDia(Id);

            return Response(resultado);
        }
    }
}
