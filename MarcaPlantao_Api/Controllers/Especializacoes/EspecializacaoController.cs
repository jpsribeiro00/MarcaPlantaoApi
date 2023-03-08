using MarcaPlantao.Aplicacao.Consultas.Especializacoes;
using MarcaPlantao.Aplicacao.Servicos.Enderecos;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Servico.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcaPlantao_Api.Controllers.Especializacoes
{
    [ApiController]
    [AllowAnonymous]
    public class EspecializacaoController : ApiControllerBase
    {
        private readonly IEspecializacaoConsultaApp especializacaoConsultaApp;

        public EspecializacaoController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator,
            IEspecializacaoConsultaApp especializacaoConsultaApp) : base(notifications, mediator)
        {
            this.especializacaoConsultaApp = especializacaoConsultaApp;
        }

        [HttpGet("ObterTodasEspecializacao")]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await especializacaoConsultaApp.ObterTodos();

            return Response(resultado);
        }

        [HttpGet("ObterEspecializacao")]
        public async Task<IActionResult> ObterPorId(Guid Id)
        {
            var resultado = await especializacaoConsultaApp.ObterPorId(Id);

            return Response(resultado);
        }
    }
}
