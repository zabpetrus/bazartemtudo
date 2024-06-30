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
        public string product_name { get; set; }  = string.Empty;

        public string SKU { get; set; } = string.Empty;

        public string UPC { get; set; } = string.Empty;

        public decimal Valor { get; set; } = decimal.MinValue;         


    }
}
