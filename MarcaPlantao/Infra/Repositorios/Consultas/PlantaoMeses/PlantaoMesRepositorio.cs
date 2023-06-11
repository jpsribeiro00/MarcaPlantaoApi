using MarcaPlantao.Dominio.Consultas;
using MarcaPlantao.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Consultas.PlantaoMeses
{
    public class PlantaoMesRepositorio : IPlantaoMesRepositorio
    {
        private ContextoMarcaPlantao db;

        public PlantaoMesRepositorio(ContextoMarcaPlantao db)
        {
            this.db = db;
        }

        public async Task<List<PlantaoMes>> ObterIndicadorPlantaoMes(Guid clinicaId)
        {
            return await db.PlantaoMes.FromSqlRaw($"select\r\n MONTH(DataInicial) as Mes, \r\n count(Id) as Quantidade\r\nfrom Plantoes\r\nwhere \r\n DataInicial  >= DATEFROMPARTS(Year(current_timestamp),1,1)\r\n and ClinicaId = '{clinicaId}'  \r\ngroup by \r\n DataInicial").ToListAsync();
        }
    }
}
