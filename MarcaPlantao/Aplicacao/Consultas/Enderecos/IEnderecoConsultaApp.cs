using MarcaPlantao.Aplicacao.Dados.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Enderecos
{
    public interface IEnderecoConsultaApp
    {
        Task<EnderecoDados> ObterPorId(Guid id);

        Task<List<EnderecoDados>> ObterTodos();
    }
}
