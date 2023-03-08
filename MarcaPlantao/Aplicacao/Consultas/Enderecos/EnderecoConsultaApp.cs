using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao.Infra.Repositorios.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Enderecos
{
    public class EnderecoConsultaApp : IEnderecoConsultaApp
    {
        private readonly IEnderecoRepositorio enderecoRepositorio;
        private readonly IMapper mapper;

        public EnderecoConsultaApp(IEnderecoRepositorio enderecoRepositorio, IMapper mapper)
        {
            this.enderecoRepositorio = enderecoRepositorio;
            this.mapper = mapper;
        }

        public async Task<EnderecoDados> ObterPorId(Guid id)
        {
            return mapper.Map<EnderecoDados>(await enderecoRepositorio.ObterPorId(id));
        }

        public async Task<List<EnderecoDados>> ObterTodos()
        {
            return mapper.Map<List<EnderecoDados>>(await enderecoRepositorio.ObterTodos());
        }
    }
}
