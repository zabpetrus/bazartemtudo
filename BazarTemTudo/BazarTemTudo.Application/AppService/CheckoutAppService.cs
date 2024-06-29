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
    public class CheckoutAppService : AppServiceBase<CheckoutViewModel, Checkout>, ICheckoutAppService
    {
        private readonly ICheckoutService _checkoutService;
        public CheckoutAppService(ICheckoutService serviceBase, IMapper mapper, ILogger<AppServiceBase<CheckoutViewModel, Checkout>> logger) : base(serviceBase, mapper, logger)
        {
            _checkoutService = serviceBase;
        }
    }
}
