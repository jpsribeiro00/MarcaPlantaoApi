using MarcaPlantao.Dominio.Consultas;
using MarcaPlantao.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Consultas.ValorDias
{
    public class ValorDiaRepositorio : IValorDiaRepositorio
    {
        private ContextoMarcaPlantao db;

        public ValorDiaRepositorio(ContextoMarcaPlantao db)
        {
            this.db = db;
        }

        public async Task<List<ValorDia>> ObterIndicadorValorDia(Guid clinicaId)
        {
            return await db.ValorDias.FromSqlRaw($"select\r\n    DataInicial as Data,  \r\n    Sum(ValorTotal) as Valor\r\nfrom Plantoes\r\nwhere \r\n    DataInicial  >= DATEFROMPARTS(Year(current_timestamp),1,1)\r\n\tand ClinicaId = '{clinicaId}' \r\ngroup by \r\n    DataInicial").ToListAsync();
        }
    }
}
