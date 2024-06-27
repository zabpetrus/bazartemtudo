using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
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
    public class PedidosRepository : RepositoryBase<Pedidos>, IPedidosRepository
    {
        public PedidosRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
