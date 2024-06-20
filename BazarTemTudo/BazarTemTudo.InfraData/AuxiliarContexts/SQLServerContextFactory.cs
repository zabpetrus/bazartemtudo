using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.AuxiliarContexts
{
    public class SQLServerContextFactory : IDesignTimeDbContextFactory<SQLServerContext>
    {
        public SQLServerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SQLServerContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=J:\\bazar\\BazarTemTudo\\BazarTemTudo.InfraData\\Database\\ServiceDB.mdf;Integrated Security=True");
            return new SQLServerContext(optionsBuilder.Options);
        }
    }
}
