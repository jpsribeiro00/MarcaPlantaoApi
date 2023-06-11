using MarcaPlantao.Aplicacao.Dados.ValorDias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Consultas.ValorDias
{
    public interface IValorDiaConsultaApp
    {
        Task<List<ValorDiaDados>> ObterIndicadorValorDia(Guid clinicaId);
    }
}
