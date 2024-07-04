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

            builder.Property(e => e.Ship_address1)
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(e => e.Ship_address2)
            .HasMaxLength(100)
            .IsRequired(false);

            builder.Property(e => e.Ship_address3)
            .HasMaxLength(100)
            .IsRequired(false);

            builder.Property(e => e.Ship_city)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(e => e.Ship_country)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(e => e.Ship_postal_code)
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(e => e.Ship_state)
            .HasMaxLength(50)
            .IsRequired();

        }
    }
}
