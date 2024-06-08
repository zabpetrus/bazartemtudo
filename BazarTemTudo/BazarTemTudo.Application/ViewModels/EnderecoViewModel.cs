using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class EnderecoViewModel
    {

        private string _rua = string.Empty;

        private int _numero = 0;

        private string _complemento1 = string.Empty;

        private string _complemento2 = string.Empty;

        private string _cep = string.Empty;

        private string _cidade = string.Empty;

        private string _estado = string.Empty;

        private string _pais = string.Empty;

        public EnderecoViewModel()
        {
        }

        public EnderecoViewModel(string rua, int numero, string complemento1, string complemento2, string cep, string cidade, string estado, string pais)
        {
            _rua = rua;
            _numero = numero;
            _complemento1 = complemento1;
            _complemento2 = complemento2;
            _cep = cep;
            _cidade = cidade;
            _estado = estado;
            _pais = pais;

        }

        public string Rua { get => _rua; set => _rua = value; }
        public int Numero { get => _numero; set => _numero = value; }
        public string Complemento1 { get => _complemento1; set => _complemento1 = value; }
        public string Complemento2 { get => _complemento2; set => _complemento2 = value; }
        public string Cep { get => _cep; set => _cep = value; }
        public string Cidade { get => _cidade; set => _cidade = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Pais { get => _pais; set => _pais = value; }





    }
}
