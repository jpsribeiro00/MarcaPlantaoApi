using MarcaPlantao.Dominio.Consultas;
using MarcaPlantao.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Consultas.EventosClinica
{
    public class EventoClinicaRepositorio : IEventoClinicaRepositorio
    {
        private ContextoMarcaPlantao db;

        public EventoClinicaRepositorio(ContextoMarcaPlantao db)
        {
            this.db = db;
        }

        public async Task<List<EventoClinica>> BuscarEventosClinica(Guid Id)
        {
            return await db.EventosClinicas.FromSqlRaw($"Select Id as Id,Titulo as Titulo, 'Oferta' as Tipo, DataInicial as DataInicial, DataFinal as DataFinal, null as Status from Ofertas o where o.ClinicaId = '{Id}' and o.Id not in (select OfertaId from Plantoes where ClinicaId = '{Id}')\r\nUnion\r\nselect pl.Id as Id,('Plantão ' + pr.Nome) as Titulo, 'Plantao' as Tipo, DataInicial as DataInicial, DataFinal as DataFinal, pl.Status as Status  from Plantoes pl inner join Profissionais pr on pl.ProfissionalId = pr.Id where pl.ClinicaId = '{Id}'\r\n").ToListAsync();
        }
    }
}
