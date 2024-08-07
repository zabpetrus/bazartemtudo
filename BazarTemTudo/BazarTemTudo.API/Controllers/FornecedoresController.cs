﻿using BazarTemTudo.API.Controllers._Base;
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

        [HttpGet]
        public override IActionResult Get()
        {
            var result = _fornecedoresAppService.GetAll();
            return Ok(result);
        }



        [HttpPost]
        public IActionResult Create(FornecedoresViewModel fornecedores)
        {
            try
            {
                // Iniciar transação no Unit of Work
                _unitOfWork.BeginTransaction();

                // Verificar se o objeto fornecedores é nulo
                if (fornecedores == null)
                {
                    throw new ArgumentNullException("Um objeto de entrada é necessário");
                }   
                

                // Adicionar o fornecedor usando o serviço de aplicação de fornecedores
                _fornecedoresAppService.Add(fornecedores);

                // Salvar todas as mudanças feitas até agora no Unit of Work
                _unitOfWork.SaveChanges();

                // Commitar a transação se tudo ocorreu sem exceções
                _unitOfWork.Commit();

                return Ok("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                // Rollback da transação em caso de exceção
                _unitOfWork.Rollback();

                // Retornar uma resposta de erro com a mensagem da exceção
                return BadRequest($"Erro ao criar fornecedor: {ex.Message}");
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

