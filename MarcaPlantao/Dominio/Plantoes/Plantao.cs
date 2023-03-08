using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Plantoes
{
    public class Plantao : Entidade
    {
        public StatusPlantao Status { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public double ValorTotal { get; set; }
        public double HoraExtra { get; set; }
        public string? Desconto { get; set; }
        public StatusPagamento StatusPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string? Comprovante { get; set; }
        public DateTime DataCadastro { get; set; }

        //Ef Relations
        public Guid ProfissionalId { get; set; }

        [ForeignKey("ProfissionalId")]
        public virtual Profissional Profissional { get; set; }

        public Guid OfertaId { get; set; }

        [ForeignKey("OfertaId")]
        public virtual Oferta Oferta { get; set; }

        public Guid ClinicaId { get; set; }

        [ForeignKey("ClinicaId")]
        public virtual Clinica Clinica { get; set; }
    }
}
