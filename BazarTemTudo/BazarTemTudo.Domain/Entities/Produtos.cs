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
        public string NomeProduto { get; set; } 

        public string SKU { get; set; }

        public string UPC { get; set; }

        public decimal Valor { get; set; }
  


    }
}
