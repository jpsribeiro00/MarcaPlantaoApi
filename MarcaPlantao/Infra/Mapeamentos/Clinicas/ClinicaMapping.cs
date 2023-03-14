using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Dominio.Enderecos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Mapeamentos.Clinicas
{
    public class ClinicaMapping : IEntityTypeConfiguration<Clinica>
    {
        public void Configure(EntityTypeBuilder<Clinica> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.RazaoSocial)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Imagem)
                .HasColumnType("varbinary");
        }
    }
}
