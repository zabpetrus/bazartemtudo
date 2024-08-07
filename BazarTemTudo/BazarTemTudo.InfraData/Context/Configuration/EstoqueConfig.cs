﻿using BazarTemTudo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Context.Configuration
{
    public class EstoqueConfig : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();

            builder.HasOne(e => e.Estoque_Produto)
                .WithOne()
                .HasPrincipalKey<Estoque>(e => e.Id)
                .HasForeignKey<Estoque>(e => e.ProdutosID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
