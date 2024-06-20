using BazarTemTudo.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.AuxiliarContexts
{
    public class PostgresContextFactory : IDesignTimeDbContextFactory<PostgresContext>
    {
        private readonly IConfiguration? _configuration;

        public PostgresContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<SQLiteContext>();
            optionsBuilder.UseSqlite("data source=J:\\bazar\\BazarTemTudo\\BazarTemTudo.InfraData\\Database\\bazarDatabase.db");
            return new PostgresContext(optionsBuilder.Options);
        }
    }
}
