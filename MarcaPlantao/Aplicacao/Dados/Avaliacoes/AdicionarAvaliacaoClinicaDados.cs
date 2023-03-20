using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Avaliacoes
{
    public class AdicionarAvaliacaoClinicaDados
    {
        public Guid ClinicaId { get; set; }
        public Guid PlantaoId { get; set; }
        public string Descricao { get; set; }
        public int Nota { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public Guid ProfissionalId { get; set; }
    }
}
