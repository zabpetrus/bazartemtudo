using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Interface.Repository._Base;
using BazarTemTudo.Domain.Interface.Service._Base;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Service._Base
{
    /*Não estou usando por causa da injeção de dependencia*/
    public  class ServiceBase<TEntity> : Notifiable<Notification>, IDisposable, IServiceBase<TEntity> where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> Repository)
        {
            _repository = Repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Create(obj);
        }           

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

      
        public TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }

      
        public void Remove(TEntity obj)
        {
             _repository.Delete(obj);   
        }
  

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

     
        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> FindAll(string args)
        {
            return _repository.SearchAll(args); 
        }
    }
}
