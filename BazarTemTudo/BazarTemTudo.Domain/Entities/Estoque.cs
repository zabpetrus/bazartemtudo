using BazarTemTudo.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Estoque : Entity
    {
        public int Produtos_ID { get; set; } 

        public int Quantidade { get; set; } = 0;

        public int Estoque_Minimo { get; set; } = 0;

        // public Produtos Produto { get; set; } = new Produtos();


        public Estoque() { }

     
    }
}
