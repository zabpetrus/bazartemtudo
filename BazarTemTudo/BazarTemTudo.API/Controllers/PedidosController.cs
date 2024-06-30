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
    public class PedidosController : CommonBaseController<PedidosViewModel>
    {
        private readonly IPedidoAppService _pedidoAppService;
        public PedidosController(IHttpContextAccessor contextAccessor, IPedidoAppService appService, IUnitOfWork unitOfWork, ILogger<PedidosViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _pedidoAppService = appService; 
        }

      
    }
}

