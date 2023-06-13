using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Alertas;
using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Infra.Repositorios.Alertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Alertas
{
    public class AlertaConsultaApp : IAlertaConsultaApp
    {
        private readonly IAlertaRepositorio alertaRepositorio;
        private readonly IMapper mapper;

        public AlertaConsultaApp(IAlertaRepositorio alertaRepositorio, IMapper mapper)
        {
            this.alertaRepositorio = alertaRepositorio;
            this.mapper = mapper;
        }

        public async Task<List<AlertaDados>> ObterPorClinica(Guid ClinicaId)
        {
            return mapper.Map<List<AlertaDados>>(await alertaRepositorio.ObterAlertaPorClinica(ClinicaId));
        }

        public async Task<List<AlertaDados>> ObterPorUsuario(Guid profissionalId)
        {
            return mapper.Map<List<AlertaDados>>(await alertaRepositorio.ObterAlertaPorUsuario(profissionalId));
        }
    }
}
