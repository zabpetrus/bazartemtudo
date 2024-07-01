using BazarTemTudo.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class NotaFiscal : Entity
    {
        
       
        public decimal Valor_Total { get; set; }

        public DateTime Data_Emissao { get; set; }

        //Links

        public long PedidoID { get; set; }

        public Pedidos Pedido { get; set; } 

    }
}
