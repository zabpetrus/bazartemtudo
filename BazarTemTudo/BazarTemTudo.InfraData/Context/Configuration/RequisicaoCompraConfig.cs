using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities.Enums;
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

            builder.Property(r => r.Total_Compra).HasColumnType("decimal(18,2)");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();

            builder.Property(e => e.Quantidade).IsRequired();

            builder.Property(e => e.Total_Compra).IsRequired();

            builder.HasOne(e => e.Fornecedor)
                .WithMany()
                .HasForeignKey(e => e.Fornecedor_ID);

            builder
              .HasOne(e => e.Produto)
              .WithMany()
              .HasForeignKey(e => e.Produto_ID)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Status_Pedido).HasConversion(
               v => Enum.GetName(typeof(StatusPedido), v),
               v => (StatusPedido)Enum.Parse(typeof(StatusPedido), v)
           );
        }
    }
}
