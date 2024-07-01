using BazarTemTudo.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class RequisicaoCompraViewModel
    {

        public int Fornecedor_ID { get; set; }

        public FornecedoresViewModel Fornecedor { get; set; } = new FornecedoresViewModel();


        public int Produto_ID { get; set; }

        public ProdutosViewModel Produto { get; set; } = new ProdutosViewModel();

        public int Quantidade { get; set; }

        public StatusPedido Status_Pedido { get; set; } = StatusPedido.Pendente;

        public decimal? Total_Compra { get; set; }

        public DateTime Data_Emissao { get; set; }

      
    }
}
