using MarcaPlantao.Aplicacao.Dados.Plantoes;
using MarcaPlantao.Aplicacao.Servicos.Plantoes;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Servico.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcaPlantao_Api.Controllers.Plantoes
{
    [ApiController]
    [AllowAnonymous]
    public class PlantaoController : ApiControllerBase
    {
        private readonly IPlantaoServicoApp plantaoServicoApp;

        public PlantaoController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IPlantaoServicoApp plantaoServicoApp) : base(notifications, mediator)
        {
            this.plantaoServicoApp = plantaoServicoApp;
        }

        [HttpGet("ObterTodasPlantoes")]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await plantaoServicoApp.ObterTodos();

            return Response(resultado);
        }

        [HttpGet("ObterPlantao")]
        public async Task<IActionResult> ObterPorId(Guid Id)
        {
            var resultado = await plantaoServicoApp.ObterPorId(Id);

            return Response(resultado);
        }

        [HttpPost("AdicionarPlantao")]
        public async Task<IActionResult> Adicionar([FromBody] GerarPlantaoDados Plantao)
        {
            var resultado = await plantaoServicoApp.AdicionarAsync(Plantao);

            return Response(resultado);
        }

        [HttpPut("AtualizarPlantao")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarPlantaoDados Plantao)
        {
            var resultado = await plantaoServicoApp.AtualizarAsync(Plantao);

            return Response(resultado);
        }

        [HttpPut("AtualizarStatusPlantao")]
        public async Task<IActionResult> AtualizarStatusPlantao([FromBody] AtualizarStatusPlantaoDados Plantao)
        {
            var resultado = await plantaoServicoApp.AtualizarStatusAsync(Plantao);

            return Response(resultado);
        }

        [HttpPut("EncerrarPlantao")]
        public async Task<IActionResult> EncerrarPlantao([FromBody] EncerrarPlantaoDados Plantao)
        {
            var resultado = await plantaoServicoApp.EncerrarPlantaoAsync(Plantao);

            return Response(resultado);
        }

        [HttpDelete("RemoverPlantao")]
        public async Task<IActionResult> Remover(Guid Id)
        {
            var resultado = await plantaoServicoApp.RemoverAsync(Id);

            return Response(resultado);
        }
    }
}
