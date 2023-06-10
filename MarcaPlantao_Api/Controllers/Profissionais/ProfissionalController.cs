using MarcaPlantao.Aplicacao.Dados.Acesso;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao.Aplicacao.Servicos.Acesso;
using MarcaPlantao.Aplicacao.Servicos.Profissionais;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Servico.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcaPlantao_Api.Controllers.Profissionais
{
    [ApiController]
    [AllowAnonymous]
    public class ProfissionalController : ApiControllerBase
    {
        private readonly IProfissionalServicoApp profissionalServico;

        public ProfissionalController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IProfissionalServicoApp profissionalServico) : base(notifications, mediator)
        {
            this.profissionalServico = profissionalServico;
        }

        [HttpGet("ObterTodosProfissionais")]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await profissionalServico.ObterTodos();

            return Response(resultado);
        }

        [HttpGet("ObterProfissional")]
        public async Task<IActionResult> ObterPorId(Guid Id)
        {
            var resultado = await profissionalServico.ObterPorId(Id);
             
            return Response(resultado);
        }

        [HttpPut("AtualizarProfissional")]
        public async Task<IActionResult> Atualizar([FromForm] AtualizarProfissionalDados profissional)
        {
            var resultado = await profissionalServico.AtualizarAsync(profissional);

            return Response(resultado);
        }
    }
}
