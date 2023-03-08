using MarcaPlantao.Aplicacao.Dados.Clinicas;
using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Ofertas
{
    public class OfertaDados
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Turno { get; set; }
        public double Valor { get; set; }
        public double ValorHoraExtra { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Pagamento { get; set; }
        public List<ProfissionalDados>? Profissionais { get; set; }
        public List<EspecializacaoDados>? Especializacoes { get; set; }
        public ClinicaDados? Clinica { get; set; }
    }
}
