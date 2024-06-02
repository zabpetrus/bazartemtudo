using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class RequisicaoCompra : Entity
    {

        public int Fornecedor_ID { get; set; }

        public Fornecedores Fornecedor { get; set; } = new Fornecedores();


        public int Produto_ID { get; set; }

        public Produtos Produto {  get; set; } = new Produtos();

        public int Quantidade { get; set; }

        public StatusPedido Status_Pedido { get; set; } = StatusPedido.Pendente;

        public decimal? Total_Compra {  get; set; } 

        public DateTime Data_Emissao { get; set; }

        public RequisicaoCompra(int fornecedor_ID, Fornecedores fornecedor, int produto_ID, Produtos produto, int quantidade, StatusPedido status_Pedido, decimal? total_Compra, DateTime data_Emissao)
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

        public RequisicaoCompra()
        {
        }
    }
}
