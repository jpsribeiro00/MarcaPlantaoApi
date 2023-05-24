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
            return await db.EventosProfissionais.FromSqlRaw($"Select o.Id as Id,Titulo as Titulo, 'Oferta' as Tipo, DataInicial as DataInicial, null as DataFinal, null as Status, cl.RazaoSocial as RazaoSocial\r\nfrom Ofertas o\r\ninner join OfertaProfissional op on o.Id = op.OfertasId\r\ninner join Clinicas cl on o.ClinicaId = cl.Id\r\nwhere op.ProfissionaisId = '{Id}'\r\nand o.DataInicial > CAST(GETDATE() AS Date)\r\nand o.Id not in (select pl.OfertaId from Plantoes pl)\r\n\r\nUnion\r\n\r\nselect pl.Id as Id,('Plantão ' + pr.Nome) as Titulo, 'Plantao' as Tipo, DataInicial as DataInicial, DataFinal as DataFinal, pl.Status as Status, cl.RazaoSocial as RazaoSocial\r\nfrom Plantoes pl\r\ninner join Profissionais pr on pl.ProfissionalId = pr.Id\r\ninner join Clinicas cl on pl.ClinicaId = cl.Id\r\nwhere pl.ProfissionalId = '{Id}'").ToListAsync();
        }
    }
}
