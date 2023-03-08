using MarcaPlantao.Aplicacao.Dados.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Eventos
{
    public interface IEventoConsultaApp
    {
        Task<List<EventoDados>> BuscarEventosClinica(Guid Id);
    }
}
