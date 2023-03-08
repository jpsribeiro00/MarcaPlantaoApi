using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Enderecos
{
    public interface IEnderecoServicoApp
    {
        Task<bool> AdicionarAsync(EnderecoDados enderecoDados);

        Task<bool> AtualizarAsync(EnderecoDados enderecoDados);

        Task<bool> RemoverAsync(Guid id);

        Task<EnderecoDados> ObterPorId(Guid id);

        Task<List<EnderecoDados>> ObterTodos();
    }
}
