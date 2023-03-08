using MarcaPlantao.Aplicacao.Dados.Plantoes;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Plantoes
{
    public interface IPlantaoConsultaApp
    {
        Task<PlantaoDados> ObterPorId(Guid idUsuario);

        Task<List<PlantaoDados>> ObterTodos();
    }
}
