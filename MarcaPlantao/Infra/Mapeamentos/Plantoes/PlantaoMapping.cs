using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Plantoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Mapeamentos.Plantoes
{
    public class PlantaoMapping : IEntityTypeConfiguration<Plantao>
    {
        public void Configure(EntityTypeBuilder<Plantao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Status)
                .IsRequired()
                .HasConversion(new EnumToNumberConverter<StatusPlantao, int>());

            builder.Property(c => c.DataInicial)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.DataFinal)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.Desconto)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.StatusPagamento)
                .HasConversion(new EnumToNumberConverter<StatusPagamento, int>());

            builder.Property(c => c.DataPagamento)
                .HasColumnType("datetime");

            builder.Property(c => c.Comprovante)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}
