using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Application.ViewModels.Enums;

namespace BazarTemTudo.InfraData.Context.Configuration
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

            builder.Property(e => e.Ship_service_level)
           .HasMaxLength(50)
           .IsRequired();

            builder.Property(e => e.Payments_Date)
            .IsRequired();


            builder.Property(e => e.Purchase_Date)
            .IsRequired();


            builder.HasMany(e => e.ItensPedidos)
                .WithOne(e => e.Pedido)
                .HasForeignKey(e => e.PedidoId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Clientes)
                .WithMany(e =>e.Pedidos)
                .HasForeignKey(e => e.ClientesId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder
                .HasOne(e => e.Endereco)
                .WithOne(e =>e.Pedido)
                .HasForeignKey<Pedidos>("Endereco_Id")
                .OnDelete(DeleteBehavior.Restrict);

            

        }
    }
}
