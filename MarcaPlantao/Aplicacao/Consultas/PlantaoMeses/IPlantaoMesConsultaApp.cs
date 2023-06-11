using MarcaPlantao.Aplicacao.Dados.PlantaoMes;
using MarcaPlantao.Dominio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.PlantaoMeses
{
    public interface IPlantaoMesConsultaApp
    {
        Task<List<PlantaoMesDados>> ObterIndicadorPlantaoMes(Guid clinicaId);
    }
}
