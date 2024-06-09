using BazarTemTudo.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Context
{
    public class SQLiteContextFactory : IDesignTimeDbContextFactory<SQLiteContext>
    {
        private readonly IConfiguration _configuration;

        public SQLiteContext CreateDbContext(string[] args)
        {
            var ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<SQLiteContext>();
            if (args.Length == 0)
            {
                optionsBuilder.UseSqlite(ConnectionString);
            }
            else
            {
                optionsBuilder.UseSqlite(args[0]);
            }
            return new SQLiteContext(optionsBuilder.Options);
        }
    }
}
