using BazarTemTudo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Configuration
{
    public class TransportadorasConfig : IEntityTypeConfiguration<Transportadoras>
    {
        public void Configure(EntityTypeBuilder<Transportadoras> builder)
        {
            builder.ToTable("Transportadoras");
        }
    }
}
