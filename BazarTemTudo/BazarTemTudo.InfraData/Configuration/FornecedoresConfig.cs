﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities.Enums;

namespace BazarTemTudo.InfraData.Configuration
{
    public class FornecedoresConfig : IEntityTypeConfiguration<Fornecedores>
    {
        public void Configure(EntityTypeBuilder<Fornecedores> builder)
        {
            builder.ToTable("Fornecedores");    
            
        }
    }
}
