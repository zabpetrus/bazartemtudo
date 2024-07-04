using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.CrossCutting.Service;
using BazarTemTudo.Domain.Entities;
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

        public CargaController(CargaService cargaService)
        {
            _cargaService = cargaService;
        }

        /// <summary>
        /// Carregar Arquivo Carga
        /// </summary>
        /// <param name="file">A File</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost("file")]
        public IActionResult CarregarArquivoCarga(IFormFile file)
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
                    if (response) { return Ok("Tabelas populadas com sucesso"); } else { return BadRequest("Ops!"); }
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
        /// <summary>
        /// Listar Carga Banco
        /// </summary>
       



    
    }
}
