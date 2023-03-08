using MarcaPlantao.Aplicacao.Consultas.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Aplicacao.Servicos.Ofertas;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Servico.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcaPlantao_Api.Controllers.Ofertas
{
    [ApiController]
    [AllowAnonymous]
    public class OfertaController : ApiControllerBase
    {
        private readonly IOfertaServicoApp ofertaServicoApp;

        public OfertaController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IOfertaServicoApp ofertaServicoApp) : base(notifications, mediator)
        {
            this.ofertaServicoApp = ofertaServicoApp;
        }

        [HttpGet("ObterTodasOfertas")]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await ofertaServicoApp.ObterTodos();

            return Response(resultado);
        }

        [HttpGet("ObterOferta")]
        public async Task<IActionResult> ObterPorId(Guid Id)
        {
            var resultado = await ofertaServicoApp.ObterPorId(Id);

            return Response(resultado);
        }

        [HttpPost("AdicionarOferta")]
        public async Task<IActionResult> Adicionar([FromBody] OfertaDados Oferta)
        {
            var resultado = await ofertaServicoApp.AdicionarAsync(Oferta);

            return Response(resultado);
        }

        [HttpPut("AtualizarOferta")]
        public async Task<IActionResult> Atualizar([FromBody] OfertaDados Oferta)
        {
            var resultado = await ofertaServicoApp.AtualizarAsync(Oferta);

            return Response(resultado);
        }

        [HttpDelete("RemoverOferta")]
        public async Task<IActionResult> Remover(Guid Id)
        {
            var resultado = await ofertaServicoApp.RemoverAsync(Id);

            return Response(resultado);
        }
    }
}
