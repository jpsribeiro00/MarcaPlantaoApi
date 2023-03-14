using MarcaPlantao.Dominio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Consultas.EventosProfissional
{
    public interface IEventosProfissionalRepositorio
    {
        Task<List<EventoProfissional>> BuscarEventosProfissional(Guid Id);
    }
}
