using BazarTemTudo.API.Controllers._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.InfraData.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensPedidosController : CommonBaseController<ItensPedidosViewModel>
    {
        private readonly IItensPedidosAppService _itenspedidosAppService;
        public ItensPedidosController(IHttpContextAccessor contextAccessor, IItensPedidosAppService appService, IUnitOfWork unitOfWork, ILogger<ItensPedidosViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _itenspedidosAppService = appService;
        }


     
    }
}
