using BazarTemTudo.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Interface.Service._Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {

        void Add(TEntity obj);

        TEntity GetById(long id);

        IEnumerable<TEntity> GetAll();

        void Update(long id, TEntity obj);

        bool RemoveById(long id);

        void AddRange(IEnumerable<TEntity> entities);

        void Create(TEntity entity);

        void UpdateMultiples(IEnumerable<TEntity> entities);

        bool Delete(long id);

        void DeleteMultiples(IEnumerable<TEntity> entities);

        int Search(string expression);

        List<TEntity> SearchAll(string expression);

        long GetID(TEntity entity);

        long CreateGetID(TEntity entity);

        IEnumerable<TEntity> FindAll(TEntity args);

        TEntity Find(TEntity entity);


    }
}
