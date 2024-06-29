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
    public class ProdutosController : CommonBaseController<ProdutosViewModel>
    {
        private readonly IProdutosAppService _produtosAppService;
        public ProdutosController(IHttpContextAccessor contextAccessor, IProdutosAppService appService, IUnitOfWork unitOfWork, ILogger<ProdutosViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _produtosAppService = appService;
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Post([FromBody] ProdutosViewModel entity) => NotFound();


        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Update(long Id, ProdutosViewModel entity) => NotFound();



        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete([FromBody] long Id) => NotFound();

    }
}
