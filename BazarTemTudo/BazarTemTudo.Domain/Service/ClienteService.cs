using AutoMapper;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Interface;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.Domain.Interface.Repository._Base;
using BazarTemTudo.Domain.Service._Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Service
{
    public class ClienteService : ServiceBase<Clientes>, IClienteService
    {
        private readonly IClientesRepository _clienteRepository;
        
        public ClienteService(IClientesRepository clientesRepository) : base(clientesRepository)
        {
            _clienteRepository = clientesRepository;
        }
    }
}
