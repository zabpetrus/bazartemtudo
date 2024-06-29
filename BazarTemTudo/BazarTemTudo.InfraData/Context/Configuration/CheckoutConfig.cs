using BazarTemTudo.Domain.Entities;
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
        }
    }
}
