using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class CargaViewModel
    {
        public int order_id { get; set; }
        public string order_item_id { get; set; }
        public DateTime purchase_date { get; set; }
        public DateTime payments_date { get; set; }
        public string buyer_email { get; set; }
        public string buyer_name { get; set; }
        public string cpf { get; set; }
        public string buyer_phone_number { get; set; }
        public string sku { get; set; }
        public string upc { get; set; }
        public string product_name { get; set; }
        public int quantity_purchased { get; set; }
        public string currency { get; set; }
        public decimal item_price { get; set; }
        public string ship_service_level { get; set; }
        public string ship_address_1 { get; set; }
        public string ship_address_2 { get; set; }
        public string ship_address_3 { get; set; }
        public string ship_city { get; set; }
        public string ship_state { get; set; }
        public string ship_postal_code { get; set; }
        public string ship_country { get; set; }

    }
}
