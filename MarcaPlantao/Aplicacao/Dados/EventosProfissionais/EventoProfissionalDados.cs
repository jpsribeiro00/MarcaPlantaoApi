﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.EventosProfissionais
{
    public class EventoProfissionalDados
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
    }
}
