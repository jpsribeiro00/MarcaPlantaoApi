﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Ofertas
{
    public class AtualizarOfertaDados
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Turno { get; set; }
        public double Valor { get; set; }
        public double ValorHoraExtra { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Pagamento { get; set; }
    }
}
