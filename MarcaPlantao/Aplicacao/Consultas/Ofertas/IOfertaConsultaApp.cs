using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Dominio.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Ofertas
{
    public interface IOfertaConsultaApp
    {
        Task<ObterOfertaDados> ObterPorId(Guid id);

        Task<List<ObterOfertaDados>> ObterTodos();

        Task<List<ListaOfertasAbertasProfissional>> ObterOfertasAbertasParaProfissional(Guid ProfissionalId);
    }
}
