using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.EventosProfissionais;
using MarcaPlantao.Infra.Repositorios.Consultas.EventosClinica;
using MarcaPlantao.Infra.Repositorios.Consultas.EventosProfissional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.EventosProfissionais
{
    public class EventoProfissionalConsultaApp : IEventoProfissionalConsultaApp
    {
        private readonly IEventosProfissionalRepositorio eventoRepositorio;
        private readonly IMapper mapper;

        public EventoProfissionalConsultaApp(IEventosProfissionalRepositorio eventoRepositorio, IMapper mapper)
        {
            this.eventoRepositorio = eventoRepositorio;
            this.mapper = mapper;
        }

        public async Task<List<EventoProfissionalDados>> BuscarEventosProfissional(Guid Id)
        {
            return mapper.Map<List<EventoProfissionalDados>>(await eventoRepositorio.BuscarEventosProfissional(Id));
        }
    }
}
