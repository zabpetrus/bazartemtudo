using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Interface.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Interface.Repository
{
    public interface ICargaRepository 
    {
        void CreateMultiples(IEnumerable<Carga> entities);

        IEnumerable<Carga> GetAll();

        bool TruncateCarga();

        bool PopulateTables();


    }
}
