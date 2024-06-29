using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities._Base._Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Endereco : Entity
    {

        public int order_id { get; set; }

        public string ship_address1 { get; set; }

        public string ship_address2 { get; set; }

        public string ship_address3 { get; set; }

        public string ship_city { get; set; }

        public string ship_state { get; set; }

        public string ship_postal_code { get; set; }

        public string ship_country { get; set; }


        // Navegação
        public Pedidos Pedido { get; set; }

        public Endereco()
        {
        }

        public Endereco(string ship_address1, string ship_address2, string ship_address3, string ship_city, string ship_state, string ship_postal_code, string ship_country)
        {
            this.ship_address1 = ship_address1;
            this.ship_address2 = ship_address2;
            this.ship_address3 = ship_address3;
            this.ship_city = ship_city;
            this.ship_state = ship_state;
            this.ship_postal_code = ship_postal_code;
            this.ship_country = ship_country;
             AddNotifications(new EnderecoContract(this));

        }
    }
}
        
