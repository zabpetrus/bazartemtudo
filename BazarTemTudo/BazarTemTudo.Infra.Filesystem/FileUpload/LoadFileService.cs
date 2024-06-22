using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace BazarTemTudo.Infra.Filesystem.FileUpload
{
    public class LoadFileService
    {

        public static async Task<bool> LoadFileFromFileSystem(IFormFile file)
        {

            try
            {
                // Ler o arquivo txt
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    var content = await streamReader.ReadToEndAsync();

                    // Processar o conteúdo JSON
                    // Aqui você pode desserializar o JSON e fazer o que for necessário com ele
                    var pedidos = JsonConvert.DeserializeObject<List<CargaViewModel>>(content); 

                    // Faça algo com os pedidos (por exemplo, salvar no banco de dados)

                    Console.WriteLine("Arquivo processado com sucesso: ");
                    Console.Write(pedidos);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a carga do arquivo: " + ex);
            }
           
        }

        public static List<CargaViewModel> LoadTxtFileContent(IFormFile file)
        {
            List<CargaViewModel> listacarga = new List<CargaViewModel>();

            try
            {
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    // Ler a primeira linha (cabeçalhos) sem fazer nada
                    streamReader.ReadLine();

                    // Ler o arquivo linha por linha
                    while (!streamReader.EndOfStream)
                    {
                        var linha = streamReader.ReadLine();

                        if (linha != null)
                        {
                            // Dividir a linha em campos usando ';' como delimitador
                            string[] campos = linha.Trim().Split(';');

                            // Verificar se a linha tem o número correto de campos
                            if (campos.Length != 22)
                            {
                                throw new FormatException("A linha do arquivo não possui o número correto de campos.");
                            }

                            // Criar um objeto CargaViewModel e fazer o parse dos campos
                            CargaViewModel carga = new CargaViewModel();

                           

                            carga.order_id = Int16.Parse(campos[0]);
                            carga.order_item_id = campos[1];
                            carga.purchase_date = DateTime.ParseExact(campos[2], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            carga.payments_date = DateTime.ParseExact(campos[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            carga.buyer_email = campos[4];
                            carga.buyer_name = campos[5];
                            carga.cpf = campos[6];
                            carga.buyer_phone_number = campos[7];
                            carga.sku = campos[8];
                            carga.upc = campos[9];
                            carga.product_name = campos[10];
                            carga.quantity_purchased = Int16.Parse(campos[11]);
                            carga.currency = campos[12];
                            carga.item_price = Decimal.Parse(campos[13]);
                            carga.ship_service_level = campos[14];
                            carga.ship_address_1 = campos[15];
                            carga.ship_address_2 = campos[16];
                            carga.ship_address_3 = campos[17];
                            carga.ship_city = campos[18];
                            carga.ship_state = campos[19];
                            carga.ship_postal_code = campos[20];
                            carga.ship_country = campos[21];

                            // Adicionar o objeto CargaViewModel à lista
                            listacarga.Add(carga);
                        }
                    }
                }

                if (listacarga.Count == 0)
                {
                    throw new Exception("O arquivo não contém dados válidos para processar.");
                }

                return listacarga;
            }
            catch (FormatException ex)
            {
                throw new FormatException("Erro de formato ao processar o arquivo CSV.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante o processamento do arquivo.", ex);
            }
        }


    }
}
