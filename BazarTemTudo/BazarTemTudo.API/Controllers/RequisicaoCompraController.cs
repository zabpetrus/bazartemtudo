using BazarTemTudo.API.Controllers._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.CrossCutting.Service;
using BazarTemTudo.Domain.Entities.Enums;
using BazarTemTudo.InfraData.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarTemTudo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisicaoCompraController : CommonBaseController<RequisicaoCompraViewModel>
    {
        private readonly IRequisicaoCompraAppService _requisicaoAppService;
        private readonly IEstoqueAppService _estoqueAppService;
        private readonly PopulationService _populationService;

        public RequisicaoCompraController(
            IHttpContextAccessor contextAccessor, 
            IEstoqueAppService estoqueAppService,
            PopulationService populationService,
            IRequisicaoCompraAppService appService, 
            IUnitOfWork unitOfWork, 
            ILogger<RequisicaoCompraViewModel> logger) : base(contextAccessor, appService, unitOfWork, logger)
        {
            _requisicaoAppService = appService; 
            _populationService = populationService;
            _estoqueAppService = estoqueAppService;
        }

        [HttpPut]
        public IActionResult AtualizandoEstoque(long Id, StatusPedido statusPedido)
        {

            try
            {
                var requisicao = _requisicaoAppService.GetById(Id);
                requisicao.Status_Pedido = statusPedido;

                if (_requisicaoAppService.Update(Id, requisicao))
                {
                    if(statusPedido == StatusPedido.Entregue)
                    {
                        var estoqueId = requisicao.Produto_ID;
                        var estoque = _estoqueAppService.GetByProductId(estoqueId);
                        estoque.Quantidade = requisicao.Quantidade;

                    if (_estoqueAppService.Update(estoqueId, estoque))
                    {                           

                        return Ok(statusPedido);
                    }
                    else
                    {
                        throw new Exception("Erro durante a atualização do estoque");
                    }
                    }
                    else
                    {
                       return Ok("Nenhuma alteração substancial");
                    }
                  
                }
                else
                {
                    throw new Exception("Erro ao atualizar a requisição de compra");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro genérico: {ex.Message}");
            }
        }


    }
}
