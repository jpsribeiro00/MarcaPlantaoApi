using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Ofertas
{
    public class ListaOfertasAbertasProfissional
    {
        public Guid Id { get; set; }
        public Guid ClinicaId { get; set; }
        public string Titulo { get; set; } 
        public string RazaoSocial { get; set; }
        public byte[]? ImagemClinica { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime DataCadastro { get; set; }
        public double Valor { get; set; }
        public double ValorHoraExtra { get; set; }
        public int Pagamento { get; set; }
        public string Turno { get; set; }
        public List<EspecializacaoSimplificadoDados>? Especializacoes { get; set; }
        public EnderecoDados Endereco { get; set; }
        public bool Candidatado { get; set; }
    }
}
