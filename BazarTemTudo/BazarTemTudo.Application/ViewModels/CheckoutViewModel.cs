using BazarTemTudo.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class CheckoutViewModel
    {
        public long Pedido_Id { get; set; }

        public PedidosViewModel Pedido_Cliente { get; set; }

        public decimal Total_Pedido { get; set; }

        public StatusDespacho Status_Despacho { get; set; }

        public DateTime DataDespacho { get; set; } = new DateTime();

       
    }
}
