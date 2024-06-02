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
        public int Pedido_Id { get; set; }  

        public Pedidos Pedido_Cliente { get; set; }  = new Pedidos();

        public decimal Total_Pedido {  get; set; }  

        public StatusDespacho Status_Despacho { get; set; }

        public DateTime DataDespacho { get; set; }  = new DateTime();

        public Checkout(int pedido_Id, Pedidos pedido_Cliente, decimal total_Pedido, StatusDespacho status_Despacho, DateTime dataDespacho)
        {
            Pedido_Id = pedido_Id;
            Pedido_Cliente = pedido_Cliente;
            Total_Pedido = total_Pedido;
            Status_Despacho = status_Despacho;
            DataDespacho = dataDespacho;              
        }

        public Checkout()
        {
        }
    }
}
