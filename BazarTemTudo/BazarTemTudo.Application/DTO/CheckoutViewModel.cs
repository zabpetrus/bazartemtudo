using BazarTemTudo.Application.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.DTO
{
    public class CheckoutViewModel
    {
        public int Pedido_Id { get; set; }

        public PedidosViewModel Pedido_Cliente { get; set; } = new PedidosViewModel();

        public decimal Total_Pedido { get; set; }

        public StatusDespacho Status_Despacho { get; set; }

        public DateTime DataDespacho { get; set; } = new DateTime();

        public CheckoutViewModel(int pedido_Id, PedidosViewModel pedido_Cliente, decimal total_Pedido, StatusDespacho status_Despacho, DateTime dataDespacho)
        {
            Pedido_Id = pedido_Id;
            Pedido_Cliente = pedido_Cliente;
            Total_Pedido = total_Pedido;
            Status_Despacho = status_Despacho;
            DataDespacho = dataDespacho;
        }

        public CheckoutViewModel()
        {
        }
    }
}
