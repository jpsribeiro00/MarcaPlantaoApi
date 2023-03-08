using MarcaPlantao.Dominio.Profissionais;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Usuarios
{
    public class ApplicationUser : IdentityUser
    {
        public bool Master { get; set; }

        //Ef Relations
        public Guid? ClinicaId { get; set; }
    }
}
