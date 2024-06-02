using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Pedidos : Entity
    {
        public string Codigo_Pedido {  get; set; } = string.Empty;

        public Clientes Clientes_Id { get; set; } = new Clientes();

        public DateTime Data_Pedido { get; set; }

        public Endereco Endereco_Entrega { get; set; } = new Endereco();

        public StatusPedido Status_Pedido { get; set; } = StatusPedido.Pendente;

        public Pedidos(string codigo_Pedido, Clientes clientes_Id, DateTime data_Pedido, Endereco endereco_Entrega, StatusPedido status_Pedido)
        {
            Codigo_Pedido = codigo_Pedido;
            Clientes_Id = clientes_Id;
            Data_Pedido = data_Pedido;
            Endereco_Entrega = endereco_Entrega;
            Status_Pedido = status_Pedido;
        }

        public Pedidos()
        {
        }
    }
}
