using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class RequisicaoCompraViewModel
    {
        public long Id { get; set; }

        public long Fornecedor_ID { get; set; } = 1;

        public long Produto_ID { get; set; }

        public int Quantidade { get; set; }

        public StatusPedido Status_Pedido { get; set; } = StatusPedido.Pendente;

        public decimal? Total_Compra { get; set; }

        public DateTime Data_Emissao { get; set; }

        //Mapeamento

        public Fornecedores Fornecedor { get; set; }

        public Produtos Produto { get; set; }

    }
}
