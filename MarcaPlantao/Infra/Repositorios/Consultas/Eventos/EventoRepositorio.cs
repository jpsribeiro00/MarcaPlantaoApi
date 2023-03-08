using MarcaPlantao.Dominio.Consultas;
using MarcaPlantao.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Consultas.Eventos
{
    public class EventoRepositorio : IEventoRepositorio
    {
        private ContextoMarcaPlantao db;

        public EventoRepositorio(ContextoMarcaPlantao db)
        {
            this.db = db;
        }

        public async Task<List<Evento>> BuscarEventosClinica(Guid Id)
        {
            return await db.Eventos.FromSqlRaw("Select Id as Id,Titulo as Titulo, 'Oferta' as Tipo, DataCadastro as DataInicial, null as DataFinal from Ofertas \r\nUnion\r\nselect pl.Id as Id,('Plantão ' + pr.Nome) as Titulo, 'Plantao' as Tipo, DataInicial as DataInicial, DataFinal as DataFinal from Plantoes pl inner join Profissionais pr on pl.ProfissionalId = pr.Id").ToListAsync();
        }
    }
}
