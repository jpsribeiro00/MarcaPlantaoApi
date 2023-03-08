using MarcaPlantao_Infraestrutura.ObjetoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Enderecos
{
    public class Endereco : Entidade
    {
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public UF UF { get; set; }

    }
}
