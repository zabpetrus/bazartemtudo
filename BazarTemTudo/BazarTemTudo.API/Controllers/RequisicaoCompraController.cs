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

            var requisicao = _requisicaoAppService.GetById(Id);

            // Verificando se a requisicao foi encontrada
            if (requisicao == null)
            {
                throw new KeyNotFoundException("Id da Requisicão não foi encontrado");
            }

            requisicao.Status_Pedido = statusPedido;

            // Atualizando a requisicao no serviço
            if (!_requisicaoAppService.Update(Id, requisicao))
            {
                throw new InvalidOperationException("Erro ao atualizar a requisição de compra");
            }

            // Verificando se o status do pedido é 'Entregue'
            if (statusPedido == StatusPedido.Entregue)
            {
                var estoqueId = requisicao.Produto_ID;

                var estoque = _estoqueAppService.GetByProductId(estoqueId);

                // Verificando se o estoque foi encontrado
                if (estoque == null)
                {
                    throw new KeyNotFoundException("Produto não encontrado no estoque: Id do produto:" + estoqueId);
                }

                estoque.Quantidade = requisicao.Quantidade;

                // Atualizando o estoque no serviço
                if (!_estoqueAppService.Update(estoqueId, estoque))
                {
                    throw new InvalidOperationException("Erro durante a atualização do estoque");
                }

                // Verificando e atualizando o estoque
                _populationService.VerficarEstoque();

                var result = _populationService.VerificarPedidosProntosEmPedidos();
                if (result != null)
                {
                    _populationService.Checkout();
                    return Ok("Produto entregue com pedidos a serem despachados");
                }
                else
                {
                    return Ok("Produto entregue e sem nenhum pedido a ser despachado");
                }
            }

            return Ok("Nenhuma alteração substancial");
        }




    }
}
