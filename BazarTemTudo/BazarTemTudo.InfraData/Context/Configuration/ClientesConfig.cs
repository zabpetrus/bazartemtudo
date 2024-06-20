using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;

namespace BazarTemTudo.InfraData.Context.Configuration
{
    public class ClientesConfig : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {

            builder.ToTable("Clientes");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();

            builder.Ignore(e => e.Not_Id);
            builder.Property(e => e.CPF).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Data_Atualizacao).IsRequired();
            builder.Property(e => e.Data_Registro).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Nome).HasMaxLength(50).IsRequired();

        }
    }
}
