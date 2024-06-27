using BazarTemTudo.API.Controllers._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.InfraData.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : CommonBaseController<CheckoutViewModel>
    {
        private readonly ICheckoutAppService _checkoutAppService;
        public CheckoutController(IHttpContextAccessor contextAccessor, ICheckoutAppService appService, IUnitOfWork unitOfWork, ILogger<CheckoutViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _checkoutAppService = appService;
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Post([FromBody] CheckoutViewModel entity)  => NotFound();
        

        /// <returns>An IActionResult.</returns>
        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Update(long Id, CheckoutViewModel entity) => NotFound();



        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete([FromBody] long Id) => NotFound();
    }
}
