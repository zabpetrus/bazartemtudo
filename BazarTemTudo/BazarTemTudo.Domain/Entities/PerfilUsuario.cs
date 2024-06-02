using BazarTemTudo.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class PerfilUsuario : Entity
    {
        public int Perfil_Usuario_ID { get; set; }  

        public Usuarios usuario { get; set; } = new Usuarios();

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty ;

        public string CPF { get; set; }  = string.Empty;

        public PerfilUsuario(Usuarios usuario, string nome, string email, string cPF)
        {
            this.usuario = usuario;
            Nome = nome;
            Email = email;
            CPF = cPF;
        }

        public PerfilUsuario()
        {
        }
    }
}
