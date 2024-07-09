using BazarTemTudo.API.Controllers._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.CrossCutting.Service;
using BazarTemTudo.InfraData.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespachoMercadoriasController : CommonBaseController<DespachoMercadoriasViewModel>
    {
        private readonly PopulationService _populationService;
        private readonly IDespachoMercadoriasAppService _despachoAppService;
        public DespachoMercadoriasController(IHttpContextAccessor contextAccessor, PopulationService populationService, IDespachoMercadoriasAppService appService, IUnitOfWork unitOfWork, ILogger<DespachoMercadoriasViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _despachoAppService = appService;   
            _populationService = populationService;
        }

        [HttpPost]
        public IActionResult VerificarProntos()
        {
            _populationService.Checkout();
            return Ok();
        }

    }
}
