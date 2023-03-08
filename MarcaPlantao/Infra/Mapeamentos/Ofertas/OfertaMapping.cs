 using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Profissionais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Mapeamentos.Ofertas
{
    public class OfertaMapping : IEntityTypeConfiguration<Oferta>
    {
        public void Configure(EntityTypeBuilder<Oferta> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.DataInicial)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.DataFinal)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.Turno)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.Pagamento)
                .IsRequired()
                .HasConversion(new EnumToNumberConverter<Pagamento, int>());
        }
    }
}
