using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazarTemTudo.Domain.Entities;

namespace BazarTemTudo.InfraData.Context.Configuration
{
    public class ProdutosConfig : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.ToTable("Produtos");


            builder.Property(p => p.Valor).HasColumnType("decimal(18,2)");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();
        }
    }
}
