using MarcaPlantao.Dominio.Alertas;
using MarcaPlantao_Infraestrutura.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Alertas
{
    public interface IAlertaRepositorio : IRepositorio<Alerta>
    {
        Task<List<Alerta>> ObterAlertaPorUsuario(Guid profissionalId);

        Task<List<Alerta>> ObterAlertaPorClinica(Guid ClinicaId);
    }
}
