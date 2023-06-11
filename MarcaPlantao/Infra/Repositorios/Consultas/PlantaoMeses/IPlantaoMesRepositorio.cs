using MarcaPlantao.Dominio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Consultas.PlantaoMeses
{
    public interface IPlantaoMesRepositorio
    {
        Task<List<PlantaoMes>> ObterIndicadorPlantaoMes(Guid clinicaId);
    }
}
