using BazarTemTudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class FornecedoresViewModel
    {
        public string Nome_Fornecedor { get; set; } = string.Empty;

        public string CNPJ { get; set; } = string.Empty;

        public long Endereco_ID { get; set; }

        public string Telefone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;

        // links
        public Endereco Endereco_Fornecedor { get; set; }
    }
}
