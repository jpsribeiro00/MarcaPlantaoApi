using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Dominio.Usuarios;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Clinicas
{
    public class Clinica : Entidade
    {
        public string RazaoSocial { get; set; }

        public byte[]? Imagem { get; set; }

        //Ef Relations
        public Guid EnderecoId { get; set; }

        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }

        public ICollection<Oferta> Ofertas { get; set; }

        public virtual ICollection<Plantao> Plantoes { get; set; }
    }
}
