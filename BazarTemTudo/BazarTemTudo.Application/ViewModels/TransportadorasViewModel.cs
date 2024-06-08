using BazarTemTudo.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class TransportadorasViewModel
    {
        public string NomeTransportadora { get; set; } = string.Empty;

        public string CNPJ { get; set; } = string.Empty;

        public TipoServico TipoServico { get; set; } = TipoServico.Normal;

        public decimal CustoFrete { get; set; }

        public TransportadorasViewModel(string nomeTransportadora, string cNPJ, TipoServico tipoServico, decimal custoFrete)
        {
            NomeTransportadora = nomeTransportadora;
            CNPJ = cNPJ;
            TipoServico = tipoServico;
            CustoFrete = custoFrete;
        }

        public TransportadorasViewModel()
        {
        }
    }
}
