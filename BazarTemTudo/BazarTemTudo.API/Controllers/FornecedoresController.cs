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
    public class FornecedoresController : CommonBaseController<FornecedoresViewModel>
    {
        private readonly IFornecedoresAppService _fornecedoresAppService;
        private readonly IEnderecoAppService _enderecoAppService;
        private readonly IUnitOfWork _unitOfWork;
        public FornecedoresController(
            IHttpContextAccessor contextAccessor, 
            IFornecedoresAppService appService,
            IEnderecoAppService enderecoAppService,
            IUnitOfWork unitOfWork,
            ILogger<FornecedoresViewModel> logger
            ) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _fornecedoresAppService = appService;
            _enderecoAppService = enderecoAppService;   
            _unitOfWork = unitOfWork;
        }


       

        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Update(long Id, FornecedoresViewModel entity) => NotFound();



        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Delete([FromBody] long Id) => NotFound();
    }
}

