using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
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
    public class RequisicaoCompraService : ServiceBase<RequisicaoCompra>, IRequisicaoCompraService
    {
        private readonly IRequisicaoCompraRepository _requisicaoCompraRepository;
        public RequisicaoCompraService(IRequisicaoCompraRepository Repository) : base(Repository)
        {
            _requisicaoCompraRepository = Repository;
        }
    }
}
