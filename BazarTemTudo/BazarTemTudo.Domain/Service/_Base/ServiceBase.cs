using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Interface._Base;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Service._Base
{
    public abstract class ServiceBase<TEntity> : Notifiable<Notification>, IServiceBase<TEntity> where TEntity : Entity
    {
        public abstract void Add(TEntity obj);
        public abstract Task AddAsync(TEntity obj);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract Task<IEnumerable<TEntity>> GetAllAsync();
        public abstract TEntity GetById(long id);
        public abstract Task<TEntity> GetByIdAsync(long id);
        public abstract void Remove(TEntity obj);
        public abstract Task RemoveAsync(TEntity obj);
        public abstract void Update(TEntity obj);
        public abstract Task UpdateAsync(TEntity obj);
    }
}
