using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;

namespace BazarTemTudo.InfraData.Configuration
{
    public class PedidosConfig : IEntityTypeConfiguration<Pedidos>
    {
        public void Configure(EntityTypeBuilder<Pedidos> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();

            builder.Property(e => e.Codigo_Pedido)
           .HasMaxLength(50)
           .IsRequired();

            builder.Property(e => e.Data_Pedido)
                    .IsRequired();               
                       

            builder.Property(e => e.Status_Pedido)
              .IsRequired()
              .HasConversion<int>();

            /*
            builder.HasOne(d => d.Cliente)
            .WithMany(p => p.Pedidos)
            .HasForeignKey(d => d.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);   */
        }
    }
}
