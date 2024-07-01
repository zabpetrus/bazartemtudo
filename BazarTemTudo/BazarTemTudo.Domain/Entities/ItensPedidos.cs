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
        public string Order_Item_id { get; set; }
        
        public decimal? Item_Price { get; set; } 

        public int Quantity_Purchased { get; set; }

       


        //Navegação
         public long PedidoId { get; set; }     

        public Pedidos Pedido { get; set; } = null!;

        public long ProdutoId {  get; set; }

        public Produtos Produtos { get; set; } = null!;

    }
}
