using BazarTemTudo.Application.Interface;
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
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Application.ViewModels;

namespace BazarTemTudo.Application.AppService
{
    public class ClienteAppService : IClientesAppService
    {

        private readonly IClientesAppService _clientesAppService;
        private readonly IClienteService _clienteService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;


        public ClienteAppService() { }

        public ClienteAppService(IClienteService clienteService, ILogger logger, IMapper mapper)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


#if TESTING
                public ClienteAppService(IClientesAppService clientesAppService)
                {
                    _clientesAppService = clientesAppService;
                }
#endif

        public void Add(ClientesViewModel obj)
        {
            _clienteService.Add(_mapper.Map<ClientesViewModel, Clientes>(obj));
        }

        public Task AddAsync(ClientesViewModel obj)
        {
            return _clienteService.AddAsync(_mapper.Map<ClientesViewModel, Clientes>(obj));

        }

        public IEnumerable<ClientesViewModel> GetAll()
        {
            var allclientes = _clienteService.GetAll();
            return _mapper.Map<List<ClientesViewModel>>(allclientes);

        }

        public async Task<IEnumerable<ClientesViewModel>> GetAllAsync()
        {
            var res = _clienteService.GetAllAsync();
            return _mapper.Map<List<ClientesViewModel>>(await res);
        }

        public ClientesViewModel GetById(long id)
        {
            var obj = _clienteService.GetById(id);
            return _mapper.Map<ClientesViewModel>(obj);
        }

        public async Task<ClientesViewModel> GetByIdAsync(long id)
        {
            var result = _clienteService.GetByIdAsync(id);
            return _mapper.Map<ClientesViewModel>(await result);
        }

        public void Remove(ClientesViewModel obj)
        {
            var res = _mapper.Map<ClientesViewModel, Clientes>(obj);
            _clienteService.Remove(res);
        }

        public Task RemoveAsync(ClientesViewModel obj)
        {
            var res = _mapper.Map<Clientes>(obj);
            return _clienteService.RemoveAsync(res);
        }

        public void Update(ClientesViewModel obj)
        {
            var res = _mapper.Map<Clientes>(obj);
            _clienteService.Update(res);
        }

        public Task UpdateAsync(ClientesViewModel obj)
        {
            var res = _mapper.Map<Clientes>(obj);
            return _clienteService.UpdateAsync(res);
        }
    }
}
