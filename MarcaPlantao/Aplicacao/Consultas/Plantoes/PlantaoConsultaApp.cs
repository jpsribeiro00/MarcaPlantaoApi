using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Plantoes;
using MarcaPlantao.Infra.Repositorios.Plantoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Plantoes
{
    public class PlantaoConsultaApp : IPlantaoConsultaApp
    {
        private readonly IPlantaoRepositorio plantaoRepositorio;
        private readonly IMapper mapper;

        public PlantaoConsultaApp(IPlantaoRepositorio plantaoRepositorio, IMapper mapper)
        {
            this.plantaoRepositorio = plantaoRepositorio;
            this.mapper = mapper;
        }

        public async Task<PlantaoDados> ObterPorId(Guid id)
        {
            return mapper.Map<PlantaoDados>(await plantaoRepositorio.ObterPlantaoProfissionalOfertaPorId(id));
        }

        public async Task<List<PlantaoDados>> ObterTodos()
        {
            return mapper.Map<List<PlantaoDados>>(await plantaoRepositorio.ObterTodasPlantaoProfissionalOferta());
        }
    }
}
