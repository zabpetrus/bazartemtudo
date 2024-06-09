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
using BazarTemTudo.Domain.Service;
using BazarTemTudo.InfraData.Mapping;

namespace BazarTemTudo.Application.AppService
{
    public class ClienteAppService : IClientesAppService
    {

        private readonly IClientesAppService _clientesAppService;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper = MapperClienteConfig.InitializeAutomapper();
        private readonly ILogger<ClienteAppService> _logger;

   
        public ClienteAppService(IClienteService clienteService, ILogger<ClienteAppService> logger, IMapper mapper)
        {
            _clienteService = clienteService;
            _logger = logger;
            _mapper = mapper;
        }

        public void Add(ClientesViewModel clientesViewModel)
        {
            if (_clienteService != null)
            {
                 var obj = _mapper.Map<ClientesViewModel, Clientes>(clientesViewModel);
                _clienteService.Add(obj);
            }
            else
            {
                throw new Exception("Erro na injeção. Service nulo");
            }

        }

      

        public IEnumerable<ClientesViewModel> GetAll()
        {
            if(_clienteService != null)
            {
                var allclientes = _clienteService.GetAll();               
                return _mapper.Map<List<ClientesViewModel>>(allclientes);
            }
            else
            {
                throw new Exception("Erro na injeção. Service nulo");
            }

        }

       

        public ClientesViewModel GetById(long id)
        {
            if (_clienteService != null)
            {
                 var obj = _clienteService.GetById(id);
                return _mapper.Map<ClientesViewModel>(obj);
            }
            else
            {
                throw new Exception("Erro na injeção. Service nulo");
            }
        }

       

        public void Remove(ClientesViewModel obj)
        {
            if( _clienteService != null )
            {
                 var res = _mapper.Map<ClientesViewModel, Clientes>(obj);
                 _clienteService.Remove(res);
            }
            else
            {
                throw new Exception("Erro na injeção. Service nulo");
            }

        }

        
        public void Update(ClientesViewModel obj)
        {
            if(_clienteService != null)
            {
                  var res = _mapper.Map<Clientes>(obj);
                  _clienteService.Update(res);
            }
            else
            {
                throw new Exception("Erro na injeção. Service nulo");
            }
        }

       
    }
}
