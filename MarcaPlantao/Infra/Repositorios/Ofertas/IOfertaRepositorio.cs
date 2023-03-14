using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao_Infraestrutura.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Ofertas
{
    public interface IOfertaRepositorio : IRepositorio<Oferta>
    {
        Task<Oferta> ObterOfertaProfissionalEspecializacaoPorId(Guid Id);

        Task<List<Oferta>> ObterTodasOfertaProfissionalEspecializacao();
    }
}
