using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.API.Controllers
{
    /// <summary>
    /// Carga Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CargaController : ControllerBase
    {
        /// <summary>
        /// Obter Carga
        /// </summary>
        /// <param name="jsonResult">A Json Result</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost]
        public IActionResult ObterCarga(JsonResult jsonResult)
        {
              
              return new OkObjectResult(jsonResult);
        }
    }
}
