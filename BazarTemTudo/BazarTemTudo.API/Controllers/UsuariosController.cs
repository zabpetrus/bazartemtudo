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
    public class UsuariosController : CommonBaseController<UsuariosViewModel>
    {
        private readonly IUsuariosAppService _usuariosAppService;
        public UsuariosController(IHttpContextAccessor contextAccessor, IUsuariosAppService appService, IUnitOfWork unitOfWork, ILogger<UsuariosViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _usuariosAppService = appService;   
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Post([FromBody] UsuariosViewModel entity) => NotFound();


        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Update(long Id, UsuariosViewModel entity) => NotFound();



        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete([FromBody] long Id) => NotFound();



    }
}
