using BazarTemTudo.InfraData.Context;
using BazarTemTudo.TesteConsole.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.TesteConsole.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        public DbSet<Carga> Carga { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carga>(entity =>
            {
                entity.Property(e => e.item_price)
                    .HasColumnType("decimal(18, 2)"); // Define a precisão e a escala da coluna item_price

              
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
