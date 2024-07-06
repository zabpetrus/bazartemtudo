using BazarTemTudo.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class TransportadorasViewModel
    {
        public string NomeTransportadora { get; set; } = String.Empty;

        public string CNPJ { get; set; } = String.Empty;

        public TipoServico TipoServico { get; set; } = TipoServico.Normal;

        public Shipping Shipping { get; set; }

        public decimal CustoFrete { get; set; }

        

    }
}
