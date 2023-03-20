using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Dominio.Usuarios;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Avaliacao
{
    public class AvaliacaoClinica : Avaliacao
    {
        //Ef Relations
        public Guid ClinicaId { get; set; }
        [ForeignKey("ClinicaId")]
        public virtual Clinica Clinica { get; set; }

        public Guid ProfissionalId { get; set; }
        [ForeignKey("ProfissionalId")]
        public virtual Profissional Profissional { get; set; }
    }
}
