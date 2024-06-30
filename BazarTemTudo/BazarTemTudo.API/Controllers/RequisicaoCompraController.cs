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
    public class RequisicaoCompraController : CommonBaseController<RequisicaoCompraViewModel>
    {
        private readonly IRequisicaoCompraAppService _requisicaoAppService;
        public RequisicaoCompraController(IHttpContextAccessor contextAccessor, IRequisicaoCompraAppService appService, IUnitOfWork unitOfWork, ILogger<RequisicaoCompraViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _requisicaoAppService = appService; 
        }

    
    }
}
