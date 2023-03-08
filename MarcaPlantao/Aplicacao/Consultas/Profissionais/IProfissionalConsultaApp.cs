using MarcaPlantao.Aplicacao.Dados.Profissionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Profissionais
{
    public interface IProfissionalConsultaApp
    {
        Task<ProfissionalDados> ObterPorId(Guid idUsuario);

        Task<List<ProfissionalDados>> ObterTodos();
    }
}
