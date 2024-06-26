using BazarTemTudo.Application.Interface._Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VEL.Infra.Data.UnitWork;

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
            _appService.GetAll();
            _logger.LogInformation($"Handling GET request for {typeof(T).Name}");
            return Ok();
        }


        /// <summary>
        /// Post
        /// </summary>
        /// <param name="entity">An Entity</param>
        /// <returns>An IActionResult.</returns>
       
        [HttpPost]
        public virtual IActionResult Post([FromBody] T entity)
        {
            _appService.Add( entity );  
            _logger.LogInformation($"Handling POST request for {typeof(T).Name}");
            // Lógica genérica para POST
            return Ok($"This is a generic POST method for {typeof(T).Name}");
        }


        /// <summary>
        /// Update
        /// </summary>
        /// <param name="Id">An Id</param>
        /// <param name="entity">An Entity</param>
        /// <returns>An IActionResult.</returns>
        [HttpPut]
        public virtual IActionResult Update(long Id,  T entity)
        {
            _appService.Update(Id, entity);
            _logger.LogInformation($"Handling POST request for {typeof(T).Name}");
            // Lógica genérica para POST
            return Ok($"This is a generic POST method for {typeof(T).Name}");
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Id">An Id</param>
        /// <returns>An IActionResult.</returns>
        [HttpDelete]
        public virtual IActionResult Delete([FromBody] long Id)
        {
            _appService.RemoveById (Id);
            _logger.LogInformation($"Handling POST request for {typeof(T).Name}");
            // Lógica genérica para POST
            return Ok($"This is a generic POST method for {typeof(T).Name}");
        }

    }
}
