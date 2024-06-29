using AutoMapper;
using BazarTemTudo.Application.AppService._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Interface.Service;
using BazarTemTudo.Domain.Interface.Service._Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.AppService
{
    public class EnderecoAppService : AppServiceBase<EnderecoViewModel, Endereco>, IEnderecoAppService
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoAppService(IEnderecoService serviceBase, IMapper mapper, ILogger<AppServiceBase<EnderecoViewModel, Endereco>> logger) : base(serviceBase, mapper, logger)
        {
            _enderecoService = serviceBase;
        }
    }
}
