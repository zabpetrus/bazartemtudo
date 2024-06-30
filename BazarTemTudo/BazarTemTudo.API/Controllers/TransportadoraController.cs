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
    public class TransportadoraController : CommonBaseController<TransportadorasViewModel>
    {
        private readonly ITransportadorasAppService _transportadorasAppService;
        public TransportadoraController(IHttpContextAccessor contextAccessor, ITransportadorasAppService appService, IUnitOfWork unitOfWork, ILogger<TransportadorasViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _transportadorasAppService = appService;
        }

       
    }
}
