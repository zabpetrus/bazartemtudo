using BazarTemTudo.API.Controllers._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VEL.Infra.Data.UnitWork;

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

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Post([FromBody] ClientesViewModel entity) => NotFound();


        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Update(long Id, ClientesViewModel entity) => NotFound();



        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete([FromBody] long Id) => NotFound();


    }
}
