using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class PerfilUsuarioViewModel
    {
        public int Perfil_Usuario_ID { get; set; }

        public UsuariosViewModel usuario { get; set; } = new UsuariosViewModel();

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        public PerfilUsuarioViewModel(UsuariosViewModel usuario, string nome, string email, string cPF)
        {
            this.usuario = usuario;
            Nome = nome;
            Email = email;
            CPF = cPF;
        }

        public PerfilUsuarioViewModel()
        {
        }
    }
}
