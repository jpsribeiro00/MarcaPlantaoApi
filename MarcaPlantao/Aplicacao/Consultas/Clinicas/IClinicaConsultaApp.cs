using MarcaPlantao.Aplicacao.Dados.Clinicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Clinicas
{
    public interface IClinicaConsultaApp
    {
        Task<ClinicaDados> ObterPorId(Guid id);

        Task<List<ClinicaDados>> ObterTodos();
    }
}
