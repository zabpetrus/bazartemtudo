using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.InfraData.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.API.Controllers._Base
{
    /// <summary>
    /// Common Base Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommonBaseController<T> : ControllerBase where T : class
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAppServiceBase<T> _appService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<T> _logger;

        public CommonBaseController(
            IHttpContextAccessor contextAccessor, 
            IAppServiceBase<T> appService,
            IUnitOfWork unitOfWork, 
            ILogger<T> logger
            )
        {
            _contextAccessor = contextAccessor;
            _appService = appService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        /// <summary>
        /// Get
        /// </summary>
        /// <returns>An IActionResult.</returns>
        [HttpGet]
        public virtual IActionResult Get()
        {
            var result = _appService.GetAll();
            _logger.LogInformation($"Handling GET request for {typeof(T).Name}");
            return Ok(result);
        }

                

    }
}
