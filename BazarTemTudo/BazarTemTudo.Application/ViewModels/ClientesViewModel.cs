using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class ClientesViewModel
    {
        public string Nome { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public DateTime DataNascimento;

        public ClientesViewModel() { }

        public ClientesViewModel(string nome, string cPF, string email, DateTime dataNascimento)
        {
            Nome = nome;
            CPF = cPF;
            Email = email;
            DataNascimento = dataNascimento;
        }


    }
}
