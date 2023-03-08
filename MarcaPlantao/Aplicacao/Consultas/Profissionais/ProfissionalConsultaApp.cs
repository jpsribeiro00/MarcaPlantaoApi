using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao.Infra.Repositorios.Profissionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Profissionais
{
    public class ProfissionalConsultaApp : IProfissionalConsultaApp
    {
        private readonly IProfissionalRepositorio profissionalRepositorio;
        private readonly IMapper mapper;

        public ProfissionalConsultaApp(IProfissionalRepositorio profissionalRepositorio, IMapper mapper)
        {
            this.profissionalRepositorio = profissionalRepositorio;
            this.mapper = mapper;
        }

        public async Task<ProfissionalDados> ObterPorId(Guid id)
        {
            return mapper.Map<ProfissionalDados>(await profissionalRepositorio.ObterPorId(id));
        }

        public async Task<List<ProfissionalDados>> ObterTodos()
        {
            return mapper.Map<List<ProfissionalDados>>(await profissionalRepositorio.ObterTodos());
        }
    }
}
