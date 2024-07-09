using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Checkout : Entity
    {


        public long Pedido_Id { get; set; }

        public Pedidos Pedido_Cliente { get; set; }

        public decimal Total_Pedido { get; set; }

        public StatusDespacho Status_Despacho { get; set; }

        public DateTime DataDespacho { get; set; } = new DateTime();


    }
}
