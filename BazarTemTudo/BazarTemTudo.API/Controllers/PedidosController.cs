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

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Post([FromBody] PedidosViewModel entity) => NotFound();


        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Update(long Id, PedidosViewModel entity) => NotFound();



        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete([FromBody] long Id) => NotFound();
    }
}

