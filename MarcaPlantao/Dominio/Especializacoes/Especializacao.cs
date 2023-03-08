using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Especializacoes
{
    public class Especializacao : Entidade
    {
        public string Descricao { get; set; }

        //Ef Relations 
        public virtual ICollection<Profissional> Profissionais { get; set; }

        public virtual ICollection<Oferta> Ofertas { get; set; }
    }
}
