using BazarTemTudo.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Produtos : Entity
    {
        public string Nome_Produto { get; set; }  = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public string SKU { get; set; } = string.Empty;

        public string UPC { get; set; } = string.Empty;

        public decimal Valor { get; set; } = decimal.MinValue;

        public decimal Frete_Produto { get; set; } = decimal.MinValue;
      
        public int Fornecedor_ID { get; set; }  

        public Fornecedores Fornecedor { get; set; } = new Fornecedores();

        public Produtos(string nome_Produto, string descricao, string sKU, string uPC, decimal valor, decimal frete_Produto, int fornecedor_ID, Fornecedores fornecedor)
        {
            Nome_Produto = nome_Produto;
            Descricao = descricao;
            SKU = sKU;
            UPC = uPC;
            Valor = valor;
            Frete_Produto = frete_Produto;
            Fornecedor_ID = fornecedor_ID;
            Fornecedor = fornecedor;
        }

        public Produtos()
        {
        }
    }
}
