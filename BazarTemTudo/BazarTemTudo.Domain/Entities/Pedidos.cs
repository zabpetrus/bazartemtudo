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

        public int ClienteId { get; set; } = 1;

        public DateTime Data_Pedido { get; set; }

        public int Endereco_entrega_Id { get; set; } = 1;

        public StatusPedido Status_Pedido { get; set; } = StatusPedido.Pendente;


        //Navegação
       // public Clientes Cliente { get; set; }

        //public Endereco Endereco_entrega { get; set; }  



        

        public Pedidos()
        {
        }
    }
}
