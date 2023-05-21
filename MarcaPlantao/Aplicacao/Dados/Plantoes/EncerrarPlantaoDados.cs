using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Plantoes
{
    public class EncerrarPlantaoDados
    {
        public Guid Id { get; set; }
        public Guid ProfissionalId { get; set; }
        public Guid ClinicaId { get; set; }
        public string Descricao { get; set; }
        public int Nota { get; set; }
        public string Comprovante { get; set; }
        public DateTime DataFinal { get; set; }
        public double ValorTotal { get; set; }
        public double HoraExtra { get; set; }
        public string Desconto { get; set; }
        public DateTime DataAvaliacao { get; set; }
    }
}
