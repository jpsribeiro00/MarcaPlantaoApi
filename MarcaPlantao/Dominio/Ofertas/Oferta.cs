using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Ofertas
{
    public class Oferta : Entidade
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Turno { get; set; }
        public double Valor { get; set; }
        public double ValorHoraExtra { get; set; }
        public Pagamento Pagamento { get; set; }
        public DateTime DataCadastro { get; set; }

        //Ef Relations
        public Guid ClinicaId { get; set; }
        [ForeignKey("ClinicaId")]
        public virtual Clinica Clinica { get; set; }

        public virtual ICollection<Profissional> Profissionais { get; set; }

        public virtual ICollection<Especializacao> Especializacoes { get; set; }
    }
}
