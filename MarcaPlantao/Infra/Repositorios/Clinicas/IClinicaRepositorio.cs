using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao_Infraestrutura.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Clinicas
{
    public interface IClinicaRepositorio : IRepositorio<Clinica>
    {
        Task<Clinica> ObterClinicaEnderecoPorId(Guid Id);

        Task<List<Clinica>> ObterTodasClinicaEndereco();
    }
}
