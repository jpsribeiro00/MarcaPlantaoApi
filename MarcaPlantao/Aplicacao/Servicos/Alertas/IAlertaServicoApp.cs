using MarcaPlantao.Aplicacao.Dados.Alertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Alertas
{
    public interface IAlertaServicoApp
    {
        Task<bool> RemoverAsync(Guid id);

        Task<List<AlertaDados>> ObterPorUsuario(string UsuarioId);

        Task<List<AlertaDados>> ObterPorClinica(Guid ClinicaId);
    }
}
