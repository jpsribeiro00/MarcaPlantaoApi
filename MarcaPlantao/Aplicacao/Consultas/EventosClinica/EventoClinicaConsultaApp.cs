using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.EventosClinica;
using MarcaPlantao.Infra.Repositorios.Consultas.EventosClinica;
using MarcaPlantao.Infra.Repositorios.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.EventosClinica
{
    public class EventoClinicaConsultaApp : IEventoClinicaConsultaApp
    {
        private readonly IEventoClinicaRepositorio eventoRepositorio;
        private readonly IMapper mapper;

        public EventoClinicaConsultaApp(IEventoClinicaRepositorio eventoRepositorio, IMapper mapper)
        {
            this.eventoRepositorio = eventoRepositorio;
            this.mapper = mapper;
        }

        public async Task<List<EventoClinicaDados>> BuscarEventosClinica(Guid Id)
        {
            return mapper.Map<List<EventoClinicaDados>>(await eventoRepositorio.BuscarEventosClinica(Id));
        }
    }
}
