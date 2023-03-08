using MarcaPlantao.Aplicacao.Dados.Plantoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Plantoes
{
    public interface IPlantaoServicoApp
    {
        Task<bool> AdicionarAsync(GerarPlantaoDados foto);

        Task<bool> AtualizarAsync(PlantaoDados foto);

        Task<bool> RemoverAsync(Guid id);

        Task<PlantaoDados> ObterPorId(Guid idUsuario);

        Task<List<PlantaoDados>> ObterTodos();
    }
}
