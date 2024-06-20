using BazarTemTudo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BazarTemTudo.Infra.Filesystem.FileUpload
{
    public class CargaFileService
    {
        public static async Task<bool> LoadFileFromFileSystem(IFormFile file)
        {

            try
            {
                // Ler o arquivo JSON
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    var content = await streamReader.ReadToEndAsync();

                    // Processar o conteúdo JSON
                    // Aqui você pode desserializar o JSON e fazer o que for necessário com ele
                    var pedidos = JsonConvert.DeserializeObject<List<Carga>>(content);

                    // Faça algo com os pedidos (por exemplo, salvar no banco de dados)

                    Console.WriteLine("Arquivo processado com sucesso");

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a carga do arquivo");
            }
           
        }
    }
}
