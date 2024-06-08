using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class UsuariosViewModel
    {
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public int Endereco_ID { get; set; }

        public EnderecoViewModel Endereco_Usuario { get; set; } = new EnderecoViewModel();

        public UsuariosViewModel(string nome, string email, string cPF, int endereco_ID, EnderecoViewModel endereco_Usuario)
        {
            Nome = nome;
            Email = email;
            CPF = cPF;
            Endereco_ID = endereco_ID;
            Endereco_Usuario = endereco_Usuario;
        }

        public UsuariosViewModel()
        {
        }
    }
}
