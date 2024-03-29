﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Profissionais
{
    public class AtualizarProfissionalDados
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public IFormFile? Imagem { get; set; }
        public string CRM { get; set; }
        public string CPF { get; set; }
        public string Sobre { get; set; }
    }
}
