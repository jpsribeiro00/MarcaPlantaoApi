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

        public async Task<ObterProfissionalDados> ObterPorId(Guid id)
        {
            return mapper.Map<ObterProfissionalDados>(await profissionalRepositorio.ObterProfissionalPorId(id));
        }

        public async Task<List<ObterProfissionalDados>> ObterTodos()
        {
            return mapper.Map<List<ObterProfissionalDados>>(await profissionalRepositorio.ObterTodosProfissionais());
        }
    }
}
