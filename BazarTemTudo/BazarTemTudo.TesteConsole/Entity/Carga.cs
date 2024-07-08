using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BazarTemTudo.TesteConsole.Entity
{
    public class Carga
    {
        public int Id { get; set; }

        [JsonPropertyName("order-id")]
        public string order_id { get; set; }

        [JsonPropertyName("order_item_id")]
        public string order_item_id { get; set; }

        [JsonPropertyName("purchase_date")]
        public DateTime purchase_date { get; set; }

        [JsonPropertyName("payments_date")]
        public DateTime payments_date { get; set; }

        [JsonPropertyName("buyer_email")]
        public string buyer_email { get; set; }

        [JsonPropertyName("buyer_name")]
        public string buyer_name { get; set; }

        [JsonPropertyName("cpf")]
        public string cpf { get; set; }

        [JsonPropertyName("buyer_phone_number")]
        public string buyer_phone_number { get; set; }

        [JsonPropertyName("sku")]
        public string sku { get; set; }

        [JsonPropertyName("upc")]
        public string upc { get; set; }

        [JsonPropertyName("product_name")]
        public string product_name { get; set; }

        [JsonPropertyName("quantity_purchased")]
        public int quantity_purchased { get; set; }

        [JsonPropertyName("currency")]
        public string currency { get; set; }

        [JsonPropertyName("item_price")]
        public decimal item_price { get; set; }

        [JsonPropertyName("ship_service_level")]
        public string ship_service_level { get; set; }

        [JsonPropertyName("ship_address_1")]
        public string ship_address_1 { get; set; }

        [JsonPropertyName("ship_address_2")]
        public string ship_address_2 { get; set; }

        [JsonPropertyName("ship_address_3")]
        public string ship_address_3 { get; set; }

        [JsonPropertyName("ship_city")]
        public string ship_city { get; set; }

        [JsonPropertyName("ship_state")]
        public string ship_state { get; set; }

        [JsonPropertyName("ship_postal_code")]
        public string ship_postal_code { get; set; }

        [JsonPropertyName("ship_country")]
        public string ship_country { get; set; }
    }
}
