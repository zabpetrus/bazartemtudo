using BazarTemTudo.Domain.Entities;
using Flunt.Notifications;
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
    internal class CargaConfig : IEntityTypeConfiguration<Carga>
    {
        public void Configure(EntityTypeBuilder<Carga> builder)
        {
            

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd();

            // Configurações adicionais para propriedades, se necessário
            builder.Property(e => e.order_id).IsRequired();
            builder.Property(e => e.order_item_id).IsRequired().HasMaxLength(50);
            builder.Property(e => e.purchase_date).IsRequired();
            builder.Property(e => e.payments_date).IsRequired();
            builder.Property(e => e.buyer_email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.buyer_name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.cpf).IsRequired().HasMaxLength(50);
            builder.Property(e => e.buyer_phone_number).IsRequired().HasMaxLength(30);
            builder.Property(e => e.sku).IsRequired().HasMaxLength(50);
            builder.Property(e => e.upc).IsRequired().HasMaxLength(50);
            builder.Property(e => e.product_name).IsRequired().HasMaxLength(200);
            builder.Property(e => e.quantity_purchased).IsRequired();
            builder.Property(e => e.currency).IsRequired().HasMaxLength(10);
            builder.Property(e => e.item_price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(e => e.ship_service_level).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ship_address_1).IsRequired().HasMaxLength(200);
            builder.Property(e => e.ship_address_2).HasMaxLength(200);
            builder.Property(e => e.ship_address_3).HasMaxLength(200);
            builder.Property(e => e.ship_city).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ship_state).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ship_postal_code).IsRequired().HasMaxLength(20);
            builder.Property(e => e.ship_country).IsRequired().HasMaxLength(100);


            builder.ToTable("Carga");
        }
    }
}
