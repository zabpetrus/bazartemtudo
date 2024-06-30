using BazarTemTudo.API.Controllers._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.InfraData.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.API.Controllers
{
    /// <summary>
    /// Cliente Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : CommonBaseController<ClientesViewModel>
    {
        private readonly IClientesAppService _clientesAppService;
        public ClienteController(IHttpContextAccessor contextAccessor, IClientesAppService appService, IUnitOfWork unitOfWork, ILogger<ClientesViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
           _clientesAppService = appService;
        }

       


    }
}
