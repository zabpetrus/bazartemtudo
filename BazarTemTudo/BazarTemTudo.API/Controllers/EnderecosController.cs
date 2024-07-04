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
    public class EnderecosController : CommonBaseController<EnderecoViewModel>
    {
        private readonly IEnderecoAppService _appService;
        public EnderecosController(IHttpContextAccessor contextAccessor, IEnderecoAppService appService, IUnitOfWork unitOfWork, ILogger<EnderecoViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _appService = appService;
        }
    }
}
