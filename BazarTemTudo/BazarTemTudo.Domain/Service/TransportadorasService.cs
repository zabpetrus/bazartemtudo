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
    public class TransportadorasService : ServiceBase<Transportadoras>, ITransportadorasService
    {
        private readonly ITransportadorasRepository _transportadorasRepository;
        public TransportadorasService(ITransportadorasRepository Repository) : base(Repository)
        {
            _transportadorasRepository = Repository;    
        }
    }
}
