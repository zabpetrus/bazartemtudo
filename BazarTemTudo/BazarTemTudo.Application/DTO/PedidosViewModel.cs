using BazarTemTudo.Application.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.DTO
{
    public class PedidosViewModel
    {
        public string Codigo_Pedido { get; set; } = string.Empty;

        public ClientesViewModel Clientes_Id { get; set; } = new ClientesViewModel();

        public DateTime Data_Pedido { get; set; }

        public EnderecoViewModel Endereco_Entrega { get; set; } = new EnderecoViewModel();

        public StatusPedido Status_Pedido { get; set; } = StatusPedido.Pendente;

        public PedidosViewModel(string codigo_Pedido, ClientesViewModel clientes_Id, DateTime data_Pedido, EnderecoViewModel endereco_Entrega, StatusPedido status_Pedido)
        {
            Codigo_Pedido = codigo_Pedido;
            Clientes_Id = clientes_Id;
            Data_Pedido = data_Pedido;
            Endereco_Entrega = endereco_Entrega;
            Status_Pedido = status_Pedido;
        }

        public PedidosViewModel()
        {
        }
    }
}
