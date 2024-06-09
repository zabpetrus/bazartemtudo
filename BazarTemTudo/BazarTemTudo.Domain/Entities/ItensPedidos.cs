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

        public int Produtos_ID { get; set; }    

        public int Quantidade {  get; set; }

        public decimal Preco {  get; set; }

        public bool disponivel_estoque {  get; set; }

        //Links

       // public Pedidos Pedido { get; set; } = new Pedidos();

        //public Produtos Produto { get; set; } = new Produtos();

        public ItensPedidos()
        {
        }
    }
}
