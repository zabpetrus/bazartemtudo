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
    public class ItensPedidosConfig : IEntityTypeConfiguration<ItensPedidos>
    {
        public void Configure(EntityTypeBuilder<ItensPedidos> builder)
        {
            builder.ToTable("ItensPedidos");

            builder.Property(i => i.Item_Price)
            .HasColumnType("decimal(18,2)");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();

            builder.HasOne(e => e.Pedido)
                .WithMany(e =>e.ItensPedidos)
                .HasForeignKey(e => e.PedidoId)
                .IsRequired();

            builder.HasOne(e => e.Produtos)
                .WithOne(e =>e.itensPedidos)
                .HasForeignKey<ItensPedidos>(e =>e.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
