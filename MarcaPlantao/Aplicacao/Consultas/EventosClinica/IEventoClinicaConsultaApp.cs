using MarcaPlantao.Aplicacao.Dados.EventosClinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.EventosClinica
{
    public interface IEventoClinicaConsultaApp
    {
        Task<List<EventoClinicaDados>> BuscarEventosClinica(Guid Id);
    }
}
