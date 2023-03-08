using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Especializacoes
{
    public class EspecializacaoDados
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public List<ProfissionalDados>? Profissionais { get; set; }
        public List<OfertaDados>? Ofertas { get; set; }
    }
}
