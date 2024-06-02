using BazarTemTudo.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class ItensPedidos : Entity
    {
        public int Pedidos_ID { get; set; }

        public Pedidos Pedido {  get; set; } = new Pedidos();

        public int Produtos_ID { get; set; }    

        public Produtos Produto { get; set; } = new Produtos();

        public int Quantidade {  get; set; }

        public decimal Preco {  get; set; }

        public bool disponivel_estoque {  get; set; }

        public ItensPedidos(int pedidos_ID, Pedidos pedido, int produtos_ID, Produtos produto, int quantidade, decimal preco, bool disponivel_estoque)
        {
            Pedidos_ID = pedidos_ID;
            Pedido = pedido;
            Produtos_ID = produtos_ID;
            Produto = produto;
            Quantidade = quantidade;
            Preco = preco;
            this.disponivel_estoque = disponivel_estoque;
        }

        public ItensPedidos()
        {
        }
    }
}
