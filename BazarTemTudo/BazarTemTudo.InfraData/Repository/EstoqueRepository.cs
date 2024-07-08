using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.InfraData.Context;
using BazarTemTudo.InfraData.Repository._Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Repository
{
    public class EstoqueRepository : RepositoryBase<Estoque>, IEstoqueRepository
    {
        private new readonly ApplicationDBContext _context;
        public EstoqueRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }


        public Estoque GetByProductId(long productId)
        {
            var res = _context.Estoque.FirstOrDefault(e => e.ProdutosID == productId);
            return res;
        }

    }
}
