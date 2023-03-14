using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Infra.Repositorios.Enderecos;
using MarcaPlantao.Infra.Repositorios.Especializacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Especializacoes
{
    public class EspecializacaoConsultaApp : IEspecializacaoConsultaApp
    {
        private readonly IEspecializacaoRepositorio especializacaoRepositorio;
        private readonly IMapper mapper;

        public EspecializacaoConsultaApp(IEspecializacaoRepositorio especializacaoRepositorio, IMapper mapper)
        {
            this.especializacaoRepositorio = especializacaoRepositorio;
            this.mapper = mapper;
        }

        public async Task<EspecializacaoSimplificadoDados> ObterPorId(Guid id)
        {
            return mapper.Map<EspecializacaoSimplificadoDados>(await especializacaoRepositorio.ObterPorId(id));
        }

        public async Task<List<EspecializacaoSimplificadoDados>> ObterTodos()
        {
            return mapper.Map<List<EspecializacaoSimplificadoDados>>(await especializacaoRepositorio.ObterTodos());
        }
    }
}
