using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.ValorDias;
using MarcaPlantao.Infra.Repositorios.Consultas.ValorDias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.ValorDias
{
    public class ValorDiaConsultaApp : IValorDiaConsultaApp
    {
        private readonly IValorDiaRepositorio valorDiaRepositorio;
        private readonly IMapper mapper;

        public ValorDiaConsultaApp(IValorDiaRepositorio valorDiaRepositorio, IMapper mapper)
        {
            this.valorDiaRepositorio = valorDiaRepositorio;
            this.mapper = mapper;
        }

        public async Task<List<ValorDiaDados>> ObterIndicadorValorDia(Guid clinicaId)
        {
            return mapper.Map<List<ValorDiaDados>>(await valorDiaRepositorio.ObterIndicadorValorDia(clinicaId));
        }
    }
}
