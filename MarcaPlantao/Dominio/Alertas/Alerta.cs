using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Dominio.Usuarios;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Dominio.Alertas
{
    public class Alerta : Entidade
    {
        public string? Mensagem { get; set; }
        public string? TipoMensagem { get; set; }
        public string? Data { get; set; }
        public string? Componente { get; set; }

        //Ef Relations
        public string UserId { get; set; }
        public Guid ClinicaId { get; set; }
    }
}
