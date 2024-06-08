using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BazarTemTudo.API.Controllers
{
    /// <summary>
    /// Clientes Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

         private readonly IClientesAppService _clientesAppService;

        public ClientesController(IClientesAppService clientesAppService)
        {
            _clientesAppService = clientesAppService;
        }


        /// <summary>
        /// Get
        /// </summary>
        /// <returns>An IEnumerable of string.</returns>
        [HttpGet]
        public IEnumerable<ClientesViewModel> Get()
        {
            return _clientesAppService.GetAll();
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id">An Id</param>
        /// <returns>A string.</returns>
        [HttpGet("{id}")]
        public ClientesViewModel Get(int id)
        {
            return _clientesAppService.GetById(id);
        }
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="value">A Value</param>
        [HttpPost]
        public void Post([FromBody] ClientesViewModel clientesViewModel)
        {
            _clientesAppService.Add(clientesViewModel);
        }
        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id">An Id</param>
        /// <param name="value">A Value</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ClientesViewModel clientesViewModel)
        {
            _clientesAppService.Update(clientesViewModel);
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">An Id</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        { 
            _clientesAppService.Remove(Get(id));    
        }
    }
}
