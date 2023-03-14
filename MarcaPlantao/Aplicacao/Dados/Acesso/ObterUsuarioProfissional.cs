using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Acesso
{
    public class ObterUsuarioProfissional : ObterUsuario
    {
        public string Nome { get; set; }
        public byte[] Imagem { get; set; }
        public List<EspecializacaoSimplificadoDados>? Especializacoes { get; set; }
    }
}
