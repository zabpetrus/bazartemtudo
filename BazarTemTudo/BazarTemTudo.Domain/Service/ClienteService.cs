using AutoMapper;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Interface;
using BazarTemTudo.Domain.Service._Base;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ClienteService() { }

        public ClienteService(IMapper mapper, ILogger<ClienteService>  logger)
        {
            _mapper = mapper;
            _logger = logger;
        }


        #if TESTING
                public ClienteService(IClienteService clienteService)
                {
                    _clienteService = clienteService;
                }
        #endif

        public void Add(Clientes obj)
        {
            Console.WriteLine("Hello World");
        }

        public Task AddAsync(Clientes obj)
        {
            return Task.Run(() => Console.WriteLine("Cliente adicionado de forma assíncrona"));
        }

        public IEnumerable<Clientes> GetAll()
        {
            List<Clientes> lista = new List<Clientes>();
            lista.Add(new Clientes("Juwanna", "123", "hermooso@gamil.com", new DateTime(2024, 9, 12)));
            return lista;
        }

        public Task<IEnumerable<Clientes>> GetAllAsync()
        {
            var lista = new List<Clientes>();
            lista.Add(new Clientes("Yelan", "1238877", "favonius@gmail.com", new DateTime(2024, 9, 12)));
            return Task.FromResult<IEnumerable<Clientes>>(lista);

        }

        public Clientes GetById(long id)
        {
            return new Clientes { Nome = "foo", CPF = "123455" };
        }

        public Task<Clientes> GetByIdAsync(long id)
        {
           return Task.FromResult(new Clientes("bams", "123456", "foo@mail.com", new DateTime(5,5,1985)));

        }

        public void Remove(Clientes obj)
        {
            Console.WriteLine("Hello");
        }

        public Task RemoveAsync(Clientes obj)
        {
           return Task.FromResult(new Clientes("Pedrita", "4123456", "foo@mail.com", new DateTime(5, 5, 1985)));
        }

        public void Update(Clientes obj)
        {
            Console.WriteLine("safjajfasf");
        }

        public Task UpdateAsync(Clientes obj)
        {
            return Task.FromResult(new Clientes("ManolCastor", "4123456", "ak@mail.com", new DateTime(6, 5, 1985)));
        }
    }
}
