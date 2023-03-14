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
            return await db.EventosClinicas.FromSqlRaw($"Select Id as Id,Titulo as Titulo, 'Oferta' as Tipo, DataCadastro as DataInicial, null as DataFinal from Ofertas o where o.ClinicaId = '{Id}' \r\nUnion\r\nselect pl.Id as Id,('Plantão ' + pr.Nome) as Titulo, 'Plantao' as Tipo, DataInicial as DataInicial, DataFinal as DataFinal from Plantoes pl inner join Profissionais pr on pl.ProfissionalId = pr.Id where pl.ClinicaId = '{Id}'").ToListAsync();
        }
    }
}
