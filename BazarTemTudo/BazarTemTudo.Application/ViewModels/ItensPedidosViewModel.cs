using BazarTemTudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class ItensPedidosViewModel
    {
        public long Id { get; set; }

        public string Order_Item_id { get; set; }

        public decimal Item_Price { get; set; }

        public int Quantity_Purchased { get; set; }

        public bool Disponivel { get; set; } = false;


        //Navegação
        public long PedidoId { get; set; }

        public Pedidos Pedido { get; set; }

        public long ProdutoId { get; set; }

        public Produtos Produtos { get; set; }
    }
}
