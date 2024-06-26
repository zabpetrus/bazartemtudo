using BazarTemTudo.API.Controllers._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VEL.Infra.Data.UnitWork;

namespace BazarTemTudo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespachoMercadoriasController : CommonBaseController<DespachoMercadoriasViewModel>
    {
        private readonly IDespachoMercadoriasAppService _despachoAppService;
        public DespachoMercadoriasController(IHttpContextAccessor contextAccessor, IDespachoMercadoriasAppService appService, IUnitOfWork unitOfWork, ILogger<DespachoMercadoriasViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _despachoAppService = appService;   
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Post([FromBody] DespachoMercadoriasViewModel entity) => NotFound();


        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Update(long Id, DespachoMercadoriasViewModel entity) => NotFound();



        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete([FromBody] long Id) => NotFound();
    }
}
