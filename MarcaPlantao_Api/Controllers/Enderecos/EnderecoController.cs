using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Servicos.Enderecos;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Servico.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcaPlantao_Api.Controllers.Enderecos
{
    [ApiController]
    [AllowAnonymous]
    public class EnderecoController : ApiControllerBase
    {
        private readonly IEnderecoServicoApp enderecoServicoApp;

        public EnderecoController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IEnderecoServicoApp enderecoServicoApp) : base(notifications, mediator)
        {
            this.enderecoServicoApp = enderecoServicoApp;
        }

        [HttpGet("ObterTodasEnderecos")]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await enderecoServicoApp.ObterTodos();

            return Response(resultado);
        }

        [HttpGet("ObterEndereco")]
        public async Task<IActionResult> ObterPorId(Guid Id)
        {
            var resultado = await enderecoServicoApp.ObterPorId(Id);

            return Response(resultado);
        }

        [HttpPost("AdicionarEndereco")]
        public async Task<IActionResult> Adicionar([FromBody] EnderecoDados Endereco)
        {
            var resultado = await enderecoServicoApp.AdicionarAsync(Endereco);

            return Response(resultado);
        }

        [HttpPut("AtualizarEndereco")]
        public async Task<IActionResult> Atualizar([FromBody] EnderecoDados Endereco)
        {
            var resultado = await enderecoServicoApp.AtualizarAsync(Endereco);

            return Response(resultado);
        }

        [HttpDelete("RemoverEndereco")]
        public async Task<IActionResult> Remover(Guid Id)
        {
            var resultado = await enderecoServicoApp.RemoverAsync(Id);

            return Response(resultado);
        }
    }
}
