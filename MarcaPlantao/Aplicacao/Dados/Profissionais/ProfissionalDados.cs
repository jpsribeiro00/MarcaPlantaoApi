using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Profissionais
{
    public class ProfissionalDados
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public byte[] Imagem { get; set; }
        public string CRM { get; set; }
        public string CPF { get; set; }
        public string UserId { get; set; }
        public List<OfertaDados>? Ofertas { get; set; }
        public List<EspecializacaoDados>? Especializacoes { get; set; }
    }
}
