using BazarTemTudo.API.Controllers._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.CrossCutting.Service;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.InfraData.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : CommonBaseController<CheckoutViewModel>
    {
        private readonly ICheckoutAppService _checkoutAppService;
        private readonly PopulationService _populationService;
        public CheckoutController(IHttpContextAccessor contextAccessor, PopulationService populationService, ICheckoutAppService appService, IUnitOfWork unitOfWork, ILogger<CheckoutViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _checkoutAppService = appService;
            _populationService = populationService;
        }

        public override IActionResult Get()
        { 
            var res = _checkoutAppService.GetAll();
            return Ok(res);
        }

       
    }
}
