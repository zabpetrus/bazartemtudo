using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Context.Configuration
{
    public class CheckoutConfig : IEntityTypeConfiguration<Checkout>
    {
        public void Configure(EntityTypeBuilder<Checkout> builder)
        {
            builder.ToTable("Checkout");

            builder.Property(c => c.Total_Pedido).HasColumnType("decimal(18,2)");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();

            builder.Property(e => e.Status_Despacho).HasConversion(
               v => Enum.GetName(typeof(StatusDespacho), v),
               v => (StatusDespacho)Enum.Parse(typeof(StatusDespacho), v)
           );

            builder
              .HasOne(e => e.Pedido)
              .WithOne()
              .HasForeignKey<Checkout>(e => e.PedidoId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
