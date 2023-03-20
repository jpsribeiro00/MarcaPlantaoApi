using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Dominio.Profissionais;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Avaliacao
{
    public class AvaliacaoProfissional : Avaliacao
    {
        //Ef Relations

        public Guid ProfissionalId { get; set; }
        [ForeignKey("ProfissionalId")]
        public virtual Profissional Profissional { get; set; }

        public Guid ClinicaId { get; set; }
        [ForeignKey("ClinicaId")]
        public virtual Clinica Clinica { get; set; }
    }
}
