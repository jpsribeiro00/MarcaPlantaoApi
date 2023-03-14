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
        Task<ObterProfissionalDados> ObterPorId(Guid idUsuario);

        Task<List<ObterProfissionalDados>> ObterTodos();
    }
}
