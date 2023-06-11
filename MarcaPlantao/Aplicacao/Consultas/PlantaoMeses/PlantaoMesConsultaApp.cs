using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.PlantaoMes;
using MarcaPlantao.Infra.Repositorios.Consultas.PlantaoMeses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.PlantaoMeses
{
    public class PlantaoMesConsultaApp : IPlantaoMesConsultaApp
    {
        private readonly IPlantaoMesRepositorio plantaoRepositorio;
        private readonly IMapper mapper;

        public PlantaoMesConsultaApp(IPlantaoMesRepositorio plantaoRepositorio, IMapper mapper)
        {
            this.plantaoRepositorio = plantaoRepositorio;
            this.mapper = mapper;
        }

        public async Task<List<PlantaoMesDados>> ObterIndicadorPlantaoMes(Guid clinicaId)
        {
            return mapper.Map<List<PlantaoMesDados>>(await plantaoRepositorio.ObterIndicadorPlantaoMes(clinicaId));
        }
    }
}
