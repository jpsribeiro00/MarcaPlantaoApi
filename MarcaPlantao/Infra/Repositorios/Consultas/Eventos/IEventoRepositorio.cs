using MarcaPlantao.Dominio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Consultas.Eventos
{
    public interface IEventoRepositorio
    {
        Task<List<Evento>> BuscarEventosClinica(Guid Id);
    }
}
