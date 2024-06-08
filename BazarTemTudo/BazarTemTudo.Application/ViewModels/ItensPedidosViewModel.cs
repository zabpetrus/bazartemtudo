using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class ItensPedidosViewModel
    {
        public int Pedidos_ID { get; set; }

        public PedidosViewModel Pedido { get; set; } = new PedidosViewModel();

        public int Produtos_ID { get; set; }

        public ProdutosViewModel Produto { get; set; } = new ProdutosViewModel();

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

        public bool disponivel_estoque { get; set; }

        public ItensPedidosViewModel(int pedidos_ID, PedidosViewModel pedido, int produtos_ID, ProdutosViewModel produto, int quantidade, decimal preco, bool disponivel_estoque)
        {
            Pedidos_ID = pedidos_ID;
            Pedido = pedido;
            Produtos_ID = produtos_ID;
            Produto = produto;
            Quantidade = quantidade;
            Preco = preco;
            this.disponivel_estoque = disponivel_estoque;
        }

        public ItensPedidosViewModel()
        {
        }
    }
}
