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
        public  int Pedidos_ID { get; set; }
       
        public decimal Valor_Total { get; set; }

        public DateTime Data_Emissao { get; set; }

        //Links
        //public Pedidos pedido_Cliente { get; set; } = new Pedidos();

        public NotaFiscal() { }
    }
}
