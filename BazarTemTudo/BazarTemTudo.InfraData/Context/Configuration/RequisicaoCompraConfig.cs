using BazarTemTudo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Context.Configuration
{
    public class RequisicaoCompraConfig : IEntityTypeConfiguration<RequisicaoCompra>
    {
        public void Configure(EntityTypeBuilder<RequisicaoCompra> builder)
        {
            builder.ToTable("RequisicaoCompra");

            builder.Property(r => r.Total_Compra)
        .HasColumnType("decimal(18,2)");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();
        }
    }
}
