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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NSQ6C33\\ATLAS;Initial Catalog=bazartemtudodb;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True;");
            return new SQLServerContext(optionsBuilder.Options);
        }
    }
}
