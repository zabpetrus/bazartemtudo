using BazarTemTudo.Application.DTO;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Service._Base;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BazarTemTudo.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BazarTemTudo.Application.Service
{
    public class ClienteAppService : AppServiceBase<ClientesViewModel>
    {

        private readonly IClientesAppService _clientesAppService;
        private readonly IClienteService _clienteService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;


        [ActivatorUtilitiesConstructor]
        public ClienteAppService(IClienteService clienteService, ILogger logger, IMapper mapper)
        {
            _clienteService = clienteService;
            _logger = logger;
            _mapper = mapper;
        }

        public ClienteAppService(IClientesAppService clientesAppService)
        {
            _clientesAppService = clientesAppService;
        }

      
        public override void Add(ClientesViewModel obj)
        {
            Console.WriteLine("123");
        }

        public override Task AddAsync(ClientesViewModel obj)
        {
            return Task.Run(() => Console.WriteLine("Cliente adicionado de forma assíncrona"));
        }

        public override IEnumerable<ClientesViewModel> GetAll()
        {
            return (IEnumerable<ClientesViewModel>)Task.Run(() => new List<ClientesViewModel>());
          
        }

        public override Task<IEnumerable<ClientesViewModel>> GetAllAsync()
        {
            return null;
        }

        public override ClientesViewModel GetById(long id)
        {
            return new ClientesViewModel { Nome = "foo", CPF = "123455" };
        }

        public override Task<ClientesViewModel> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(ClientesViewModel obj)
        {
            throw new NotImplementedException();
        }

        public override Task RemoveAsync(ClientesViewModel obj)
        {
            throw new NotImplementedException();
        }

        public override void Update(ClientesViewModel obj)
        {
            Console.WriteLine("123");
        }

        public override Task UpdateAsync(ClientesViewModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
