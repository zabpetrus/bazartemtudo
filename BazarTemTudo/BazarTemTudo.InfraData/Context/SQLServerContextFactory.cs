using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Context
{
    public class SQLServerContextFactory : IDesignTimeDbContextFactory<SQLServerContext>
    {
        public SQLServerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SQLServerContext>();
            optionsBuilder.UseSqlServer("Host=localhost;Port=5432;Database=vel_db;Username=postgres;Password=823543");
            return new SQLServerContext(optionsBuilder.Options);
        }
    }
}
