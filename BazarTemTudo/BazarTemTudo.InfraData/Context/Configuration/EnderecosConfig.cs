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
    public class EnderecosConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();

            builder.Property(e => e.Rua)
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(e => e.Pais)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(e => e.Rua)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(e => e.Estado)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(e => e.Cep)
            .HasMaxLength(20)
            .IsRequired();

        }
    }
}
