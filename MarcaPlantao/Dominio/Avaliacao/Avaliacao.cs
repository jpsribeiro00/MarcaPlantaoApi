using MarcaPlantao_Infraestrutura.ObjetoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Avaliacao
{
    public abstract class Avaliacao : Entidade
    {
        public int Nota { get; set; }

        public string Descricao { get; set; }

        public DateTime DataAvaliacao { get; set; }

        public Guid PlantaoId { get; set; }
    }
}
