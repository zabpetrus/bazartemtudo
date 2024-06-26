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
    public class FornecedoresController : CommonBaseController<FornecedoresViewModel>
    {
        private readonly IFornecedoresAppService _fornecedoresAppService;
        public FornecedoresController(IHttpContextAccessor contextAccessor, IFornecedoresAppService appService, IUnitOfWork unitOfWork, ILogger<FornecedoresViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _fornecedoresAppService = appService;
        }


        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Post([FromBody] FornecedoresViewModel entity) => NotFound();


        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Update(long Id, FornecedoresViewModel entity) => NotFound();



        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete([FromBody] long Id) => NotFound();
    }
}

