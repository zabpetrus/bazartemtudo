using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.Domain.Interface.Repository._Base;
using BazarTemTudo.Domain.Interface.Service;
using BazarTemTudo.Domain.Service._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Service
{
    public class ProdutosService : ServiceBase<Produtos>, IProdutosService
    {
        private readonly IProdutosRepository _produtosRepository;
        public ProdutosService(IProdutosRepository Repository) : base(Repository)
        {
            _produtosRepository = Repository;
        }
    }
}
