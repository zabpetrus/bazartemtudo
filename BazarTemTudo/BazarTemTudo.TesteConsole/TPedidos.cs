using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BazarTemTudo.TesteConsole
{
    public class TPedidos
    {

        private readonly ApplicationDBContext _dbContext;

        public TPedidos(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static void Main()
        {
            string filepath = "J:\\bazar\\BazarTemTudo\\BazarTemTudo.TesteConsole\\source2.json";
            string jsonContent = File.ReadAllText(filepath);
            var listacarga = new List<CargaViewModel>();
            using (JsonDocument document = JsonDocument.Parse(jsonContent))
            {
                JsonElement root = document.RootElement;
                if (root.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement element in root.EnumerateArray())
                    {
                        var carga = new CargaViewModel();
                        {
                            carga.order_id = element.GetProperty("order-id").GetString();
                            carga.order_item_id = element.GetProperty("order-item-id").GetString();
                            carga.purchase_date = DateTime.Parse( element.GetProperty("purchase_date").GetString() );
                            carga.payments_date = element.GetProperty("payments-date").GetDateTime();
                            carga.buyer_email = element.GetProperty("buyer-email").GetString();
                            carga.buyer_name = element.GetProperty("buyer-name").GetString();
                            carga.cpf = element.GetProperty("cpf").GetString();
                            carga.buyer_phone_number = element.GetProperty("buyer-phone-number").GetString();
                            carga.sku = element.GetProperty("sku").GetString();
                            carga.upc = element.GetProperty("upc").GetString();
                            carga.product_name = element.GetProperty("product-name").GetString();
                            carga.quantity_purchased = element.GetProperty("quantity-purchased").GetInt32();
                            carga.currency = element.GetProperty("currency").GetString();
                            carga.item_price = element.GetProperty("item-price").GetDecimal();
                            carga.ship_service_level = element.GetProperty("ship-service-level").GetString();
                            carga.ship_address_1 = element.GetProperty("ship-address-1").GetString();
                            carga.ship_address_2 = element.GetProperty("ship-address-2").GetString();
                            carga.ship_address_3 = element.GetProperty("ship-address-3").GetString();
                            carga.ship_city = element.GetProperty("ship-city").GetString();
                            carga.ship_state = element.GetProperty("ship-state").GetString();
                            carga.ship_postal_code = element.GetProperty("ship-postal-code").GetString();
                            carga.ship_country = element.GetProperty("ship-country").GetString();     


                         
                            // Adicione outras propriedades conforme necessário
                        };
                        listacarga.Add(carga);
                    }
                }
            }

            Console.WriteLine(jsonContent);



        }
    }

}

