using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazarTemTudo.Domain.Entities;

namespace BazarTemTudo.InfraData.Configuration
{
    public class ItensPedidosConfig : IEntityTypeConfiguration<ItensPedidos>
    {
        public void Configure(EntityTypeBuilder<ItensPedidos> builder)
        {
            builder.ToTable("ItensPedidos");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();
        }
    }
}
