﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities.Enums;

namespace BazarTemTudo.InfraData.Context.Configuration
{
    public class DespachoMercadoriasConfig : IEntityTypeConfiguration<DespachoMercadorias>
    {
        public void Configure(EntityTypeBuilder<DespachoMercadorias> builder)
        {
            builder.ToTable("DespachoMercadorias");


            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();

            builder.HasOne(e => e.Transportadora)
             .WithMany()
             .HasForeignKey(e => e.Transportadora_ID);

            builder
              .HasOne(e => e.Pedidos)
              .WithMany()
              .HasForeignKey(e => e.Pedido_Id)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Status_Entrega).HasConversion(
               v => Enum.GetName(typeof(StatusDespacho), v),
               v => (StatusDespacho)Enum.Parse(typeof(StatusDespacho), v)
           );


        }
    }
}
