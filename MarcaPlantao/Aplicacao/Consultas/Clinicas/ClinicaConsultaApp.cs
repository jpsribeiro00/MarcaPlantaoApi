using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Clinicas;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Infra.Repositorios.Clinicas;
using MarcaPlantao.Infra.Repositorios.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.Clinicas
{
    public class ClinicaConsultaApp : IClinicaConsultaApp
    {
        private readonly IClinicaRepositorio clinicaRepositorio;
        private readonly IMapper mapper;

        public ClinicaConsultaApp(IClinicaRepositorio clinicaRepositorio, IMapper mapper)
        {
            this.clinicaRepositorio = clinicaRepositorio;
            this.mapper = mapper;
        }

        public async Task<ClinicaDados> ObterPorId(Guid id)
        {
            return mapper.Map<ClinicaDados>(await clinicaRepositorio.ObterClinicaEnderecoPorId(id));
        }

        public async Task<List<ClinicaDados>> ObterTodos()
        {
            return mapper.Map<List<ClinicaDados>>(await clinicaRepositorio.ObterTodasClinicaEndereco());
        }
    }
}
