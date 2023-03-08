using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Ofertas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Mapeamentos.Especializacoes
{
    public class EspecializacaoMapping : IEntityTypeConfiguration<Especializacao>
    {
        public void Configure(EntityTypeBuilder<Especializacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");
        }
    }
}
