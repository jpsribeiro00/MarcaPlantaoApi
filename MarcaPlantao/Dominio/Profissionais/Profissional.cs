using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Usuarios;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcaPlantao.Dominio.Profissionais
{
    public class Profissional : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public byte[]? Imagem { get; set; }
        public string CRM { get; set; }
        public string CPF { get; set; }
        public string Sobre { get; set; }

        //Ef Relations
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityDbContext<ApplicationUser> User { get; set; }
        public virtual ICollection<Oferta> Ofertas { get; set; }
        public virtual ICollection<Especializacao> Especializacoes { get; set; }
        public virtual ICollection<AvaliacaoProfissional> Avaliacoes { get; set; }
    }
}
