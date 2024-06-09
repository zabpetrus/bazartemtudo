using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.InfraData.Context;
using BazarTemTudo.InfraData.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Repository
{
    public class ClientesRepository : RepositoryBase<Clientes>, IClientesRepository
    {

        private readonly SQLiteContext _context;

        public ClientesRepository(SQLiteContext context) : base(context)
        {
            _context = context;
        }
    }
}
