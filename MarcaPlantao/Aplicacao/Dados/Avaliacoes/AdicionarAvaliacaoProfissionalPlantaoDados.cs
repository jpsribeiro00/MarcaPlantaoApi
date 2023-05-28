using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Avaliacoes
{
    public class AdicionarAvaliacaoProfissionalPlantaoDados
    {
        public Guid PlantaoId { get; set; }
        public Guid ProfissionalId { get; set; }
        public Guid ClinicaId { get; set; }
        public int Nota { get; set; }
        public string Descricao { get; set; }
    }
}
