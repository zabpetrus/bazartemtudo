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

        void Update(TEntity obj);

        void Remove(TEntity obj);


    }
}
