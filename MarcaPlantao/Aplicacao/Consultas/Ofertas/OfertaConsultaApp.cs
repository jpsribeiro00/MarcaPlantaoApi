using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Infra.Repositorios.Enderecos;
using MarcaPlantao.Infra.Repositorios.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Ofertas
{
    public class OfertaConsultaApp : IOfertaConsultaApp
    {
        private readonly IOfertaRepositorio ofertaRepositorio;
        private readonly IMapper mapper;

        public OfertaConsultaApp(IOfertaRepositorio ofertaRepositorio, IMapper mapper)
        {
            this.ofertaRepositorio = ofertaRepositorio;
            this.mapper = mapper;
        }

        public async Task<ObterOfertaDados> ObterPorId(Guid id)
        {
            return mapper.Map<ObterOfertaDados>(await ofertaRepositorio.ObterOfertaProfissionalEspecializacaoPorId(id));
        }

        public async Task<List<ObterOfertaDados>> ObterTodos()
        {
            return mapper.Map<List<ObterOfertaDados>>(await ofertaRepositorio.ObterTodasOfertaProfissionalEspecializacao());
        }
    }
}
