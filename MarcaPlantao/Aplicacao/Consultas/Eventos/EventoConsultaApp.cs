using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Eventos;
using MarcaPlantao.Infra.Repositorios.Consultas.Eventos;
using MarcaPlantao.Infra.Repositorios.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Eventos
{
    public class EventoConsultaApp : IEventoConsultaApp
    {
        private readonly IEventoRepositorio eventoRepositorio;
        private readonly IMapper mapper;

        public EventoConsultaApp(IEventoRepositorio eventoRepositorio, IMapper mapper)
        {
            this.eventoRepositorio = eventoRepositorio;
            this.mapper = mapper;
        }

        public async Task<List<EventoDados>> BuscarEventosClinica(Guid Id)
        {
            return mapper.Map<List<EventoDados>>(await eventoRepositorio.BuscarEventosClinica(Id));
        }
    }
}
