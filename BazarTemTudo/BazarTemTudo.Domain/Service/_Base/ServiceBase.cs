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

              
        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> FindAll(string args)
        {
            return _repository.SearchAll(args); 
        }

        public void Update(long id, TEntity obj)
        {
            _repository.Update(id, obj);
        }

        public bool RemoveById(long id)
        {
            return _repository.Delete(id);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _repository.CreateMultiples(entities);  
        }

        public void Create(TEntity entity)
        {
            _repository.Create(entity); 
        }

        public void UpdateMultiples(IEnumerable<TEntity> entities)
        {
            _repository.UpdateMultiples(entities);  
        }

        public bool Delete(long id)
        {
            return (_repository.Delete(id));
        }

        public void DeleteMultiples(IEnumerable<TEntity> entities)
        {
            _repository.DeleteMultiples(entities);  
        }

        public int Search(string expression)
        {
            return (int) _repository.Search(expression);    
        }

        public List<TEntity> SearchAll(string expression)
        {
            return _repository.SearchAll(expression);
        }

        public long GetID(TEntity entity)
        {
            return _repository.GetID(entity);
        }

        public long CreateGetID(TEntity entity)
        {
            return _repository.CreateGetID(entity); 
        }

        public IEnumerable<TEntity> FindAll(TEntity args)
        {
            return _repository.FindAll(args);
        }

        public TEntity Find(TEntity entity)
        {
            return _repository.Find(entity);    
        }
    }
}
