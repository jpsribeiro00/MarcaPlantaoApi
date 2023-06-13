using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Alertas;
using MarcaPlantao.Infra.Repositorios.Alertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Alertas
{
    public interface IAlertaConsultaApp
    {
        Task<List<AlertaDados>> ObterPorUsuario(Guid profissionalId);

        Task<List<AlertaDados>> ObterPorClinica(Guid ClinicaId);
    }
}
