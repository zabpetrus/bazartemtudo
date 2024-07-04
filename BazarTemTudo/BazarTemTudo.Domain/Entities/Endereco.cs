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

        public string Order_id { get; set; }

        public string Ship_address1 { get; set; }

        public string Ship_address2 { get; set; }

        public string Ship_address3 { get; set; }

        public string Ship_city { get; set; }

        public string Ship_state { get; set; }

        public string Ship_postal_code { get; set; }

        public string Ship_country { get; set; }


        // Navegação
        public Pedidos Pedido { get; set; }

     

        //AddNotifications(new EnderecoContract(this));
    }
}
        
