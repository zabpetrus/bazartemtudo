using BazarTemTudo.Application.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.DTO
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

        public RequisicaoCompraViewModel(int fornecedor_ID, FornecedoresViewModel fornecedor, int produto_ID, ProdutosViewModel produto, int quantidade, StatusPedido status_Pedido, decimal? total_Compra, DateTime data_Emissao)
        {
            Fornecedor_ID = fornecedor_ID;
            Fornecedor = fornecedor;
            Produto_ID = produto_ID;
            Produto = produto;
            Quantidade = quantidade;
            Status_Pedido = status_Pedido;
            Total_Compra = total_Compra;
            Data_Emissao = data_Emissao;
        }

        public RequisicaoCompraViewModel()
        {
        }
    }
}
