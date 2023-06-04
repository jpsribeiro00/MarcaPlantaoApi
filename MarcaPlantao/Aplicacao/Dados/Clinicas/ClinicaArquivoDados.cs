using MarcaPlantao.Aplicacao.Dados.Endereco;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Clinicas
{
    public class ClinicaArquivoDados
    {
        public Guid Id { get; set; }

        public string RazaoSocial { get; set; }

        public string Sobre { get; set; }

        public IFormFile Imagem { get; set; }

        public EnderecoDados? Endereco { get; set; }
    }
}
