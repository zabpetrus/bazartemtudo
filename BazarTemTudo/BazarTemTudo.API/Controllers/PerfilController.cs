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
    public class PerfilController : CommonBaseController<PerfilUsuarioViewModel>
    {
        private readonly IPerfilUsuarioAppService _perfilAppService;
        public PerfilController(IHttpContextAccessor contextAccessor, IPerfilUsuarioAppService appService, IUnitOfWork unitOfWork, ILogger<PerfilUsuarioViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _perfilAppService = appService;
        }

    }
}
