using MarcaPlantao.Dominio.Profissionais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Mapeamentos.Profissionais
{
    public class ProfissionalMapping : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.Genero)
                .IsRequired()
                .HasColumnType("varchar(1)");

            builder.Property(c => c.Imagem)
                .HasMaxLength(8000);

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(11)");

            builder.Property(c => c.CRM)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(c => c.Sobre)
                .IsRequired()
                .HasColumnType("varchar(500)");
        }
    }
}
