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

        public int Endereco_ID { get; set; }

        public EnderecoViewModel Endereco_Fornecedor { get; set; } = new EnderecoViewModel();

        public string Telefone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;

        public FornecedoresViewModel(string nome_Fornecedor, string cNPJ, int endereco_ID, EnderecoViewModel endereco_Fornecedor, string telefone, string email, string website)
        {
            Nome_Fornecedor = nome_Fornecedor;
            CNPJ = cNPJ;
            Endereco_ID = endereco_ID;
            Endereco_Fornecedor = endereco_Fornecedor;
            Telefone = telefone;
            Email = email;
            Website = website;
        }

        public FornecedoresViewModel()
        {
        }
    }
}
