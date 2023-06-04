using MarcaPlantao.Aplicacao.Dados.Avaliacoes;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Clinicas
{
    public class ClinicaDados
    {
        public Guid Id { get; set; }

        public string RazaoSocial { get; set; }

        public byte[]? Imagem { get; set; }

        public string Sobre { get; set; }

        public EnderecoDados? Endereco { get; set; } 

        public List<AvaliacaoClinicaSimplificadoDados>? Avaliacoes { get; set; }
    }
}
