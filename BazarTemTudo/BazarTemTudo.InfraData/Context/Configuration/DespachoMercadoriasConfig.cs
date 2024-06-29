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
    public class DespachoMercadoriasConfig : IEntityTypeConfiguration<DespachoMercadorias>
    {
        public void Configure(EntityTypeBuilder<DespachoMercadorias> builder)
        {
            builder.ToTable("DespachoMercadorias");


            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();

                    


        }
    }
}
