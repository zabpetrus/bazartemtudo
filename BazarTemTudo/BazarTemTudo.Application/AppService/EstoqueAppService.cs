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
    public class EstoqueAppService : AppServiceBase<EstoqueViewModel, Estoque>, IEstoqueAppService
    {
        private readonly IEstoqueService _service;
        public EstoqueAppService(IEstoqueService serviceBase, IMapper mapper, ILogger<AppServiceBase<EstoqueViewModel, Estoque>> logger) : base(serviceBase, mapper, logger)
        {
            _service = serviceBase;
        }
    }
}
