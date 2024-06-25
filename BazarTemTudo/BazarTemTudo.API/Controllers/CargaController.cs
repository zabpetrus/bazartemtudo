using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Infra.Filesystem.FileUpload;
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
        private readonly ICargaAppService _appService;

        public CargaController(ICargaAppService appService)
        {
            _appService = appService;
        }


        /// <summary>
        /// Carregar Arquivo Carga
        /// </summary>
        /// <param name="file">A File</param>
        /// <returns>An IActionResult.</returns>
        [HttpPost("file")]
        public IActionResult CarregarArquivoCarga(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    if(file.ContentType.Contains("application/json"))
                    {
                        throw new Exception("Ainda não posso trabalhar com json...Sinto muito");
                    }


                    if (!file.ContentType.Contains("text") && !file.FileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        return BadRequest(new { message = "Tipo de arquivo não suportado. Apenas arquivos TXT são permitidos." });
                    }
                    
                    List<CargaViewModel> result = LoadFileService.LoadTxtFileContent(file);
                    _appService.AddRange(result);
                    
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
            return Ok(new { message = "Arquivo processado com sucesso" });
        }
        /// <summary>
        /// Listar Carga Banco
        /// </summary>
        [HttpGet]
        public IActionResult ListarArquivos()
        {
            var data = _appService.GetAll();
            var jsonResult =data.ToJson();
            return Ok(jsonResult);
        }



     

        [HttpDelete]
        public IActionResult DeleteCarga()
        {
            return Ok();
        }
    }
}
