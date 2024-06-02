using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Service._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Service
{
    public class ClienteService : ServiceBase<Clientes>
    {
        public override void Add(Clientes obj)
        {
            throw new NotImplementedException();
        }

        public override Task AddAsync(Clientes obj)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Clientes> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Clientes>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Clientes GetById(long id)
        {
            throw new NotImplementedException();
        }

        public override Task<Clientes> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Clientes obj)
        {
            throw new NotImplementedException();
        }

        public override Task RemoveAsync(Clientes obj)
        {
            throw new NotImplementedException();
        }

        public override void Update(Clientes obj)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Clientes obj)
        {
            throw new NotImplementedException();
        }
    }
}
