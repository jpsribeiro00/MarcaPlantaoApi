using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao_Infraestrutura.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Avaliacao
{
    public interface IAvaliacaoProfissionalRepositorio : IRepositorio<AvaliacaoProfissional>
    {
        Task<List<AvaliacaoProfissional>> ObterPorPlantaoId(Guid plantaoId);
    }
}
