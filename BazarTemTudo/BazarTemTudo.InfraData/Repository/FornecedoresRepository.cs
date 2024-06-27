using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.InfraData.Context;
using BazarTemTudo.InfraData.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Repository
{
    public class FornecedoresRepository : RepositoryBase<Fornecedores>, IFornecedoresRepository
    {
        public FornecedoresRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
