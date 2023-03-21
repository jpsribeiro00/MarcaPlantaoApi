using MarcaPlantao.Aplicacao.Dados.Plantoes;
using MarcaPlantao.Dominio.Plantoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Plantoes
{
    public interface IPlantaoServicoApp
    {
        Task<PlantaoDados> AdicionarAsync(GerarPlantaoDados foto);

        Task<bool> AtualizarAsync(AtualizarPlantaoDados foto);

        Task<bool> AtualizarStatusAsync(AtualizarStatusPlantaoDados foto);

        Task<bool> EncerrarPlantaoAsync(EncerrarPlantaoDados foto);

        Task<bool> RemoverAsync(Guid id);

        Task<PlantaoDados> ObterPorId(Guid idUsuario);

        Task<List<PlantaoDados>> ObterTodos();
    }
}
