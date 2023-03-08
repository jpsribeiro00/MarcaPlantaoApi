using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Profissionais
{
    public class ProfissonalArquivoDados
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public IFormFile? Imagem { get; set; }
        public string UserId { get; set; }
        public List<OfertaDados> Ofertas { get; set; }
        public EspecializacaoDados Especializacao { get; set; }
    }
}
