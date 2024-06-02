using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Transportadoras : Entity
    {
        public string NomeTransportadora { get; set; } = String.Empty;

        public string CNPJ { get; set; } = String.Empty;

        public TipoServico TipoServico { get; set; } = TipoServico.Normal;   

        public decimal CustoFrete { get; set; }

        public Transportadoras(string nomeTransportadora, string cNPJ, TipoServico tipoServico, decimal custoFrete)
        {
            NomeTransportadora = nomeTransportadora;
            CNPJ = cNPJ;
            TipoServico = tipoServico;
            CustoFrete = custoFrete;
        }

        public Transportadoras()
        {
        }
    }
}
