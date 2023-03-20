using MarcaPlantao.Aplicacao.Dados.Avaliacoes;
using MarcaPlantao.Aplicacao.Dados.Clinicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Clinicas
{
    public interface IClinicaServicoApp
    {
        Task<bool> AdicionarAsync(ClinicaDados clinicaDados);

        Task<bool> AtualizarAsync(ClinicaArquivoDados clinicaDados);

        Task<bool> RemoverAsync(Guid id);

        Task<ClinicaDados> ObterPorId(Guid id);

        Task<List<ClinicaDados>> ObterTodos();

        Task<bool> AdicionarAvaliacaoAsync(AdicionarAvaliacaoClinicaDados clinicaDados);
    }
}
