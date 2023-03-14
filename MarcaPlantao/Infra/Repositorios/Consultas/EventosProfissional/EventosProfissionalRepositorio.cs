using MarcaPlantao.Dominio.Consultas;
using MarcaPlantao.Infra.Contexto;
using MarcaPlantao.Infra.Repositorios.Consultas.EventosClinica;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Consultas.EventosProfissional
{
    public class EventosProfissionalRepositorio : IEventosProfissionalRepositorio
    {
        private ContextoMarcaPlantao db;

        public EventosProfissionalRepositorio(ContextoMarcaPlantao db)
        {
            this.db = db;
        }

        public async Task<List<EventoProfissional>> BuscarEventosProfissional(Guid Id)
        {
            return await db.EventosProfissionais.FromSqlRaw($"Select Id as Id,Titulo as Titulo, 'Oferta' as Tipo, DataCadastro as DataInicial, null as DataFinal from Ofertas o, OfertaProfissional op where op.ProfissionaisId = '{Id}'\r\nUnion\r\nselect pl.Id as Id,('Plantão ' + pr.Nome) as Titulo, 'Plantao' as Tipo, DataInicial as DataInicial, DataFinal as DataFinal from Plantoes pl inner join Profissionais pr on pl.ProfissionalId = pr.Id where pl.ProfissionalId = '{Id}'").ToListAsync();

        }
    }
}
