using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao.Dominio.Profissionais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Mapeamentos.Enderecos
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Rua)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnType("varchar(9)");

            builder.Property(c => c.UF)
                .IsRequired()
                .HasConversion(new EnumToNumberConverter<UF, int>());
        }
    }
}
