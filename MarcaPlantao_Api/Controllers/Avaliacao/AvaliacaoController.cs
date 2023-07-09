using MarcaPlantao.Aplicacao.Dados.Avaliacoes;
using MarcaPlantao.Aplicacao.Servicos.Avaliacao;
using MarcaPlantao.Aplicacao.Servicos.Clinicas;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Servico.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcaPlantao_Api.Controllers.Avaliacao
{
    [ApiController]
    [AllowAnonymous]
    public class AvaliacaoController : ApiControllerBase
    {
        private readonly IAvaliacaoServicoApp avaliacaoServicoApp;

        public AvaliacaoController(INotificationHandler<NotificacaoDominio> notifications, IMediatorHandler mediator
            , IAvaliacaoServicoApp avaliacaoServicoApp) : base(notifications, mediator)
        {
            this.avaliacaoServicoApp = avaliacaoServicoApp;
        }

        [HttpGet("ObterAvaliacaoClinicaParaProfissional")]
        public async Task<IActionResult> ObterAvaliacaoClinicaParaProfissional(Guid Id)
        {
            var resultado = await avaliacaoServicoApp.ObterAvaliacaoProfissional(Id);

            return Response(resultado);
        }

        [HttpGet("ObterAvaliacaoPlantao")]
        public async Task<IActionResult> ObterAvaliacaoPlantaoId(Guid Id)
        {
            var resultado = await avaliacaoServicoApp.ObterAvaliacaoPlantao(Id);

            return Response(resultado);
        }

        [HttpPut("AdicionarAvaliacaoPlantaoProfissional")]
        public async Task<IActionResult> Atualizar([FromBody] AdicionarAvaliacaoProfissionalPlantaoDados adicionarAvaliacaoProfissionalPlantaoDados)
        {
            var resultado = await avaliacaoServicoApp.AdicionarAvaliacaoProfissionalPlantao(adicionarAvaliacaoProfissionalPlantaoDados);

            return Response(resultado);
        }
    }
}
