using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.Interface._Base
{
    

    /// <summary>
    ///  Interface para os metodos
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// 

    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        //Metodos sincronos
        void Add(TEntity obj);

        TEntity GetById(long id);

        IEnumerable<TEntity> GetAll();

        bool Update(long id, TEntity obj);


        IEnumerable<TEntity> FindAll(TEntity args);

        void AddRange(IEnumerable<TEntity> entities);

        void UpdateMultiples(IEnumerable<TEntity> entities);

        bool Delete(long id);

        void DeleteMultiples(IEnumerable<TEntity> entities);

        int Search(string expression);

        List<TEntity> SearchAll(string expression);

        long GetID(TEntity entity);

        long CreateGetID(TEntity entity);


    }
}
