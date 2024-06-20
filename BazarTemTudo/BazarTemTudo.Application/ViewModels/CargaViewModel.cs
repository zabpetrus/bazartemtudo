using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class CargaViewModel
    {
        public string CodigoPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public string Sku { get; set; }
        public string Upc { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public int Qte { get; set; }
        public decimal Valor { get; set; }
        public string Fornecedor { get; set; }
        public string FornecedorCnpj { get; set; }
        public decimal Frete { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string NomeComprador { get; set; }
        public string EnderecoEntrega { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }

    }
}
