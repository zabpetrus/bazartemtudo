using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class ProdutosViewModel
    {
        public string product_name { get; set; } = string.Empty;

        public string SKU { get; set; } = string.Empty;

        public string UPC { get; set; } = string.Empty;

        public decimal Valor { get; set; } = decimal.MinValue;
      
    }
}
