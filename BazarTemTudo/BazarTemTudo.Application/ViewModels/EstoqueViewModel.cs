using BazarTemTudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class EstoqueViewModel
    {

        public long ProdutosID { get; set; }

        public int Quantidade { get; set; } = 0;

        public int Estoque_Minimo { get; set; } = 0;

        public ProdutosViewModel Estoque_Produto { get; set; }


    }
}
