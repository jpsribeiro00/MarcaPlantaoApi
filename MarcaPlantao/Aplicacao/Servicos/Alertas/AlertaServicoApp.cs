using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.AlertaComandos;
using MarcaPlantao.Aplicacao.Consultas.Alertas;
using MarcaPlantao.Aplicacao.Dados.Alertas;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Alertas
{
    public class AlertaServicoApp : IAlertaServicoApp
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediador;
        private readonly IAlertaConsultaApp alertaConsultaApp;

        public AlertaServicoApp(IMapper mapper, IMediatorHandler mediador, IAlertaConsultaApp alertaConsultaApp)
        {
            this.mapper = mapper;
            this.mediador = mediador;
            this.alertaConsultaApp = alertaConsultaApp;
        }

        public async Task<List<AlertaDados>> ObterPorClinica(Guid ClinicaId)
        {
            return await alertaConsultaApp.ObterPorClinica(ClinicaId);
        }

        public async Task<List<AlertaDados>> ObterPorUsuario(string UsuarioId)
        {
            return await alertaConsultaApp.ObterPorUsuario(UsuarioId);
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var alerta = new AlertaDados();
            alerta.Id = id;

            var removerComando = mapper.Map<RemoverAlertaComando>(alerta);
            return await mediador.EnviarComando(removerComando);
        }
    }
}
