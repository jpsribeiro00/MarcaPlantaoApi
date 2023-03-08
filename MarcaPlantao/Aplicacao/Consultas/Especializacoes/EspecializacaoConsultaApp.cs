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

        public async Task<EspecializacaoDados> ObterPorId(Guid id)
        {
            return mapper.Map<EspecializacaoDados>(await especializacaoRepositorio.ObterPorId(id));
        }

        public async Task<List<EspecializacaoDados>> ObterTodos()
        {
            return mapper.Map<List<EspecializacaoDados>>(await especializacaoRepositorio.ObterTodos());
        }
    }
}
