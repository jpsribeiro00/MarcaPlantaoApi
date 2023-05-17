using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Plantoes
{
    public class AtualizarPlantaoDados
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public double ValorTotal { get; set; }
        public double HoraExtra { get; set; }
        public string Desconto { get; set; }
        public int StatusPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string Comprovante { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
