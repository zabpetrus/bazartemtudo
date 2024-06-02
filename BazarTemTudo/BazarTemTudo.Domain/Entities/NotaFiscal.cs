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

        public Pedidos pedido_Cliente { get; set; } = new Pedidos();  

        public decimal Valor_Total { get; set; }

        public DateTime Data_Emissao { get; set; }

        public NotaFiscal(int pedidos_ID, Pedidos pedido_Cliente, decimal valor_Total, DateTime data_Emissao)
        {
            Pedidos_ID = pedidos_ID;
            this.pedido_Cliente = pedido_Cliente;
            Valor_Total = valor_Total;
            Data_Emissao = data_Emissao;
        }

        public NotaFiscal() { }
    }
}
