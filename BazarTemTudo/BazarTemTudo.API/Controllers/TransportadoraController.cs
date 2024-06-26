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
    public class TransportadoraController : CommonBaseController<TransportadorasViewModel>
    {
        private readonly ITransportadorasAppService _transportadorasAppService;
        public TransportadoraController(IHttpContextAccessor contextAccessor, ITransportadorasAppService appService, IUnitOfWork unitOfWork, ILogger<TransportadorasViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _transportadorasAppService = appService;
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Post([FromBody] TransportadorasViewModel entity) => NotFound();


        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Update(long Id, TransportadorasViewModel entity) => NotFound();



        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete([FromBody] long Id) => NotFound();
    }
}
