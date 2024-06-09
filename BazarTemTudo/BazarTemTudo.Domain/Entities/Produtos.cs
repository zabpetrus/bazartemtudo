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

        //Links
       // public Fornecedores Fornecedor { get; set; } = new Fornecedores();

       

        public Produtos()
        {
        }
    }
}
