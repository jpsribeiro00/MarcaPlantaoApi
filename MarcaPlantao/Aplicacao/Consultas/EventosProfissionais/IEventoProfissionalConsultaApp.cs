using MarcaPlantao.Aplicacao.Dados.EventosClinica;
using MarcaPlantao.Aplicacao.Dados.EventosProfissionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.EventosProfissionais
{
    public interface IEventoProfissionalConsultaApp
    {
        Task<List<EventoProfissionalDados>> BuscarEventosProfissional(Guid Id);
    }
}
