﻿using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.CrossCutting.Service;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities.Enums;
using BazarTemTudo.Infra.Filesystem.FileUpload;
using BazarTemTudo.InfraData.Procedures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace BazarTemTudo.API.Controllers
{
    /// <summary>
    /// Carga Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CargaController : ControllerBase
    {

        private readonly CargaService _cargaService;
        private readonly PopulationService _populationService;  

        public CargaController(CargaService cargaService, PopulationService populationService)
        {
            _cargaService = cargaService;
            _populationService = populationService;
        }

        /// <summary>
        /// Carregar Arquivo Carga
        /// </summary>
        /// <param name="file">A File</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost("file")]
        public IActionResult CarregarArquivoCarga(IFormFile file, TipoEstoque tipoEstoque)
        {

            var result = new List<CargaViewModel>();
           

            try
            {

                if (file != null)
                {
                    if (file == null || file.Length == 0)
                    {
                        throw new Exception("O arquivo está vazio ou não foi fornecido.");
                    }

                    if (file.ContentType.Contains("application/json"))
                    {
                        result = LoadFileService.ParseJson(file);


                    }
                    else if (file.ContentType.Contains("text/csv") || file.ContentType.Contains("text/plain"))
                    {
                        result = LoadFileService.LoadTxtFileContent(file);
                    }
                    else
                    {
                        throw new Exception("Erro: Arquivo não reconhecido");
                    }

                    var response = _cargaService.PopulateTables(result);

                    if (response) 
                    {

                        switch (tipoEstoque)
                        {
                            case TipoEstoque.Completo:
                                _populationService.SeedEstoqueAbastecido();
                                break;
                            case TipoEstoque.Variado:
                                _populationService.SeedEstoqueVariado();
                                break;
                            case TipoEstoque.Vazio:
                                _populationService.SeedEstoqueVazio();
                                break;
                            default:
                                _populationService.SeedEstoqueVazio();
                                break;
                        }

                        ProcedimentosPopulacao(_populationService);

                        _populationService.VerficarEstoque();


                        return Ok("Tabelas populadas com sucesso");
                    }
                    else
                    {
                        return BadRequest("");
                    }
                    
                }
                else
                {
                    throw new ArgumentNullException("É necessário fornecer um arquivo!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro durante o processamento do arquivo", detalhe = "Detalhes do erro: ..." + ex });
            }

         

        } 

        private static void ProcedimentosPopulacao(PopulationService populationService)
        {
            populationService.PopularFornecedores();
            populationService.PopularTransportadoras();   
        }
       
    
    }
}
