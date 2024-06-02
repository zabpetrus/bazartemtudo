using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.DTO
{
    public class EstoqueViewModel
    {
        public int Produtos_ID { get; set; }

        public ProdutosViewModel Produto { get; set; } = new ProdutosViewModel();

        public int Quantidade { get; set; } = 0;

        public int Estoque_Minimo { get; set; } = 0;


        public EstoqueViewModel() { }

        public EstoqueViewModel(int produtos_ID, ProdutosViewModel produto, int quantidade, int estoque_Minimo)
        {
            Produtos_ID = produtos_ID;
            Produto = produto;
            Quantidade = quantidade;
            Estoque_Minimo = estoque_Minimo;
        }
    }
}
