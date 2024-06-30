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
    public class EstoqueController : CommonBaseController<EstoqueViewModel>
    {
        private readonly IEstoqueAppService _estoqueAppService;
        public EstoqueController(IHttpContextAccessor contextAccessor, IEstoqueAppService appService, IUnitOfWork unitOfWork, ILogger<EstoqueViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _estoqueAppService = appService;
        }

      
    }
}

