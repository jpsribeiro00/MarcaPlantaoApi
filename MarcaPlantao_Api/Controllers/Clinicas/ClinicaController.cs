using MarcaPlantao.Aplicacao.Dados.Clinicas;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao.Aplicacao.Servicos.Clinicas;
using MarcaPlantao.Aplicacao.Servicos.Profissionais;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Servico.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcaPlantao_Api.Controllers.Clinicas
{
    [ApiController]
    [AllowAnonymous]
    public class ClinicaController : ApiControllerBase
    {
        private readonly IClinicaServicoApp clinicaServicoApp;

        public ClinicaController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IClinicaServicoApp clinicaServicoApp) : base(notifications, mediator)
        {
            this.clinicaServicoApp = clinicaServicoApp;
        }

        [HttpGet("ObterTodasClinicas")]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await clinicaServicoApp.ObterTodos();

            return Response(resultado);
        }

        [HttpGet("ObterClinica")]
        public async Task<IActionResult> ObterPorId(Guid Id)
        {
            var resultado = await clinicaServicoApp.ObterPorId(Id);

            return Response(resultado);
        }

        [HttpPut("AtualizarClinica")]
        public async Task<IActionResult> Atualizar([FromBody] ClinicaDados Clinica)
        {
            var resultado = await clinicaServicoApp.AtualizarAsync(Clinica);

            return Response(resultado);
        }
    }
}
