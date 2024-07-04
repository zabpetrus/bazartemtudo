using BazarTemTudo.API.Controllers._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.CrossCutting.Service;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.InfraData.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : CommonBaseController<EstoqueViewModel>
    {
        private readonly IEstoqueAppService _estoqueAppService;
        private readonly CargaService _cargaService;


        public EstoqueController(IHttpContextAccessor contextAccessor, CargaService cargaService, IEstoqueAppService appService, IUnitOfWork unitOfWork, ILogger<EstoqueViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _estoqueAppService = appService;
            _cargaService = cargaService;   
        }

        [HttpPost]
        public IActionResult PopularEstoque()
        {
            try
            {
                _cargaService.PopularEstoque();
                return Ok("Tabela Estoque Populada com valores iniciais");
            }
            catch (Exception ex)
            {
                return BadRequest(new Exception("Erro durante o processo: " + ex.Message, ex));
                throw; 
            }
          
        }


    }
}

