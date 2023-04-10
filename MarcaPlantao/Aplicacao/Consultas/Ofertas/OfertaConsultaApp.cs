using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Dominio.Ofertas;
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

        public async Task<List<ListaOfertasAbertasProfissional>> ObterOfertasAbertasParaProfissional(Guid ProfissionalId)
        {
            List<ListaOfertasAbertasProfissional> listaOfertasParaCandidato = new List<ListaOfertasAbertasProfissional>();

            List<Oferta> listaOfertas = await ofertaRepositorio.ObterOfertasAbertasParaProfissional();

            foreach (Oferta item in listaOfertas)
            {
                ListaOfertasAbertasProfissional ofertaParaCandidato = mapper.Map<ListaOfertasAbertasProfissional>(item);
                ofertaParaCandidato.Candidatado = item.Profissionais.Where(x => x.Id == ProfissionalId).Count() == 1;
                listaOfertasParaCandidato.Add(ofertaParaCandidato);
            }

            return listaOfertasParaCandidato;
        }
    }
}
