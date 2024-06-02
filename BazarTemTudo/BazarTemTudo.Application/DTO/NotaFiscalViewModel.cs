using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.DTO
{
    public class NotaFiscalViewModel
    {
        public int Pedidos_ID { get; set; }

        public PedidosViewModel pedido_Cliente { get; set; } = new PedidosViewModel();

        public decimal Valor_Total { get; set; }

        public DateTime Data_Emissao { get; set; }

        public NotaFiscalViewModel(int pedidos_ID, PedidosViewModel pedido_Cliente, decimal valor_Total, DateTime data_Emissao)
        {
            Pedidos_ID = pedidos_ID;
            this.pedido_Cliente = pedido_Cliente;
            Valor_Total = valor_Total;
            Data_Emissao = data_Emissao;
        }

        public NotaFiscalViewModel() { }
    }
}
