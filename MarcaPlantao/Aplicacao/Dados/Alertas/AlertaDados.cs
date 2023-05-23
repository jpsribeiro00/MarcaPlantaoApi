﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Alertas
{
    public class AlertaDados
    {
        public Guid Id { get; set; }
        public string Mensagem { get; set; }
        public string TipoMensagem { get; set; }
        public string Data { get; set; }
        public string Componente { get; set; }
    }
}
