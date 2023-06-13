using MarcaPlantao.Dominio.Alertas;
using MarcaPlantao.Dominio.Clinicas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Mapeamentos.Alertas
{
    public class AlertaMapping : IEntityTypeConfiguration<Alerta>
    {
        public void Configure(EntityTypeBuilder<Alerta> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Componente)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Data)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Mensagem)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.TipoMensagem)
                .HasColumnType("varchar(200)");
        }
    }
}
