using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.TesteConsole.Entity;
using BazarTemTudo.TesteConsole.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BazarTemTudo.TesteConsole.Uploader
{

    public class LoadCarga
    {
        private readonly CargaRepository _repository;

        public LoadCarga(CargaRepository repository)
        {
            _repository = repository;
        }

        public void LoadTxtFileContent()
        {
            List<Carga> listacarga = new List<Carga>();

            try
            {
                string filepath = "J:\\bazar\\BazarTemTudo\\BazarTemTudo.TesteConsole\\source.txt";
                string[] lines = File.ReadAllLines(filepath);

                if (lines.Length <= 1)
                {
                    throw new Exception("O arquivo não contém dados válidos para processar.");
                }

                // Ler o arquivo linha por linha
                for (int i = 1; i < lines.Length; i++) // Começa em 1 para pular os cabeçalhos
                {
                    var linha = lines[i];

                    if (!string.IsNullOrWhiteSpace(linha))
                    {
                        // Dividir a linha em campos usando ';' como delimitador
                        string[] campos = linha.Trim().Split(';');

                        // Verificar se a linha tem o número correto de campos
                        if (campos.Length != 22)
                        {
                            throw new FormatException("A linha do arquivo não possui o número correto de campos.");
                        }

                        // Criar um objeto Carga e fazer o parse dos campos
                        Carga carga = new Carga
                        {
                            order_id = campos[0],
                            order_item_id = campos[1],
                            purchase_date = DateTime.ParseExact(campos[2], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            payments_date = DateTime.ParseExact(campos[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            buyer_email = campos[4],
                            buyer_name = campos[5],
                            cpf = campos[6],
                            buyer_phone_number = campos[7],
                            sku = campos[8],
                            upc = campos[9],
                            product_name = campos[10],
                            quantity_purchased = Int16.Parse(campos[11]),
                            currency = campos[12],
                            item_price = Decimal.Parse(campos[13]),
                            ship_service_level = campos[14],
                            ship_address_1 = campos[15],
                            ship_address_2 = campos[16],
                            ship_address_3 = campos[17],
                            ship_city = campos[18],
                            ship_state = campos[19],
                            ship_postal_code = campos[20],
                            ship_country = campos[21]
                        };

                        // Adicionar o objeto Carga à lista
                        listacarga.Add(carga);
                    }
                }

                if (listacarga.Count == 0)
                {
                    throw new Exception("O arquivo não contém dados válidos para processar.");
                }

                // Serializar a lista em JSON e exibir no console
                string json = JsonSerializer.Serialize(listacarga, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(json);

                // Chamar o método do repositório para salvar os dados
                _repository.CreateMultiples(listacarga);


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
