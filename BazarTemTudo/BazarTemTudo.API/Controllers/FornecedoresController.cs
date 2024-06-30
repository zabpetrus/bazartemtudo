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

        [HttpPost]
        public IActionResult Create( FornecedoresViewModel fornecedores) 
        {
            try
            {
                _unitOfWork.BeginTransaction();

                if (fornecedores == null)
                {
                    throw new ArgumentNullException("Um objeto de entrada é necessário");
                }

                EnderecoViewModel enderecoViewModel = new EnderecoViewModel();
                enderecoViewModel.ship_address1 = fornecedores.Endereco_Fornecedor.ship_address1;
                enderecoViewModel.ship_address2 = fornecedores.Endereco_Fornecedor.ship_address2;
                enderecoViewModel.ship_address3 = fornecedores.Endereco_Fornecedor.ship_address3;
                enderecoViewModel.ship_state = fornecedores.Endereco_Fornecedor.ship_state;
                enderecoViewModel.ship_city = fornecedores.Endereco_Fornecedor.ship_city;
                enderecoViewModel.ship_postal_code = fornecedores.Endereco_Fornecedor.ship_postal_code;
                enderecoViewModel.ship_country = fornecedores.Endereco_Fornecedor.ship_country;

                _enderecoAppService.Add(enderecoViewModel);


                _fornecedoresAppService.Add(fornecedores);
            }
            catch (Exception ex)
            {

            }
          
        }



        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Update(long Id, FornecedoresViewModel entity) => NotFound();



        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Delete([FromBody] long Id) => NotFound();
    }
}

