using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Avaliacoes;
using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Infra.Repositorios.Avaliacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.AvaliacaoPlantao
{
    public class AvaliacaoPlantaoConsultaApp : IAvaliacaoPlantaoConsultaApp
    {
        private readonly IMapper mapper; 
        private readonly IAvaliacaoClinicaRepositorio avaliacaoClinicaRepositorio;
        private readonly IAvaliacaoProfissionalRepositorio avaliacaoProfissionalRepositorio;

        public AvaliacaoPlantaoConsultaApp(IMapper mapper, IAvaliacaoClinicaRepositorio avaliacaoClinicaRepositorio, IAvaliacaoProfissionalRepositorio avaliacaoProfissionalRepositorio)
        {
            this.mapper = mapper;
            this.avaliacaoClinicaRepositorio = avaliacaoClinicaRepositorio;
            this.avaliacaoProfissionalRepositorio = avaliacaoProfissionalRepositorio;
        }

        public async Task<object> ObterAvaliacaoPlantao(Guid plantaoId) 
        {
            return new {
                avaliacaoClinica = await avaliacaoClinicaRepositorio.ObterPorPlantaoId(plantaoId),
                avaliacaoProfissional = await avaliacaoProfissionalRepositorio.ObterPorPlantaoId(plantaoId)
            };
        }

        public async Task<List<ObterAvaliacaoClinicaParaProfissional>> ObterAvaliacaoProfissionais(Guid profissionalId)
        {
            return mapper.Map<List<ObterAvaliacaoClinicaParaProfissional>>(await avaliacaoClinicaRepositorio.ObterPorProfissionaisId(profissionalId));
        }
    }
}
