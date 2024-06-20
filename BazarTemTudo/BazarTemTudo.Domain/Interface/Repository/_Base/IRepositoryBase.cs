using BazarTemTudo.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Interface.Repository._Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity GetById(object id);

        IEnumerable<TEntity> GetAll();

        void Create(TEntity entity);

        void CreateMultiples(IEnumerable<TEntity> entities);

        void Update(long id, TEntity entity);

        void UpdateMultiples(IEnumerable<TEntity> entities);

        bool Delete(long id);

        void DeleteMultiples(IEnumerable<TEntity> entities);

        int Search(string expression);

        List<TEntity> SearchAll(string expression);

        void Dispose();
    }
}
