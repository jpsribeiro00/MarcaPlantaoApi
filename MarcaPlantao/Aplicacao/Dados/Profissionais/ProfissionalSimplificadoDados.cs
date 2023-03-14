using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Profissionais
{
    public class ProfissionalSimplificadoDados
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public byte[] Imagem { get; set; }
    }
}
