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
        //Metodos sincronos
        void Add(TEntity obj);

        TEntity GetById(long id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        IEnumerable<TEntity> FindAll( string args );
      
    }
}
