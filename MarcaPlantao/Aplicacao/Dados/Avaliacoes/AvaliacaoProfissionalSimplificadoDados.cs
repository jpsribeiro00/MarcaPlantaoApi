using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Avaliacoes
{
    public class AvaliacaoProfissionalSimplificadoDados
    {
        public Guid Id { get; set; }
        public Guid PlantaoId { get; set; }
        public string Descricao { get; set; }
        public int Nota { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public string Clinica { get; set; }
    }
}
