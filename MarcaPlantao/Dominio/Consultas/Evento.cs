using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Consultas
{
    public class Evento
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
    }
}
