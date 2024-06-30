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

        public long Fornecedor_ID { get; set; } = 1;
       
        public long Produto_ID { get; set; }

        public int Quantidade { get; set; }

        public StatusPedido Status_Pedido { get; set; } = StatusPedido.Pendente;

        public decimal? Total_Compra {  get; set; } 

        public DateTime Data_Emissao { get; set; }

        //Mapeamento

        public Fornecedores Fornecedor { get; set; } = new Fornecedores();

        public Produtos Produto { get; set; } = new Produtos();



        public RequisicaoCompra()
        {
        }
    }
}
