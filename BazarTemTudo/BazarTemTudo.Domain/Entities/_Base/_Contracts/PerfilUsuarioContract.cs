using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities._Base._Contracts
{
    public class PerfilUsuarioContract : Contract<PerfilUsuario>
    {
        public PerfilUsuarioContract(PerfilUsuario perfilUsuario) 
        {
            Requires()
            .IsNotNullOrEmpty(perfilUsuario.Nome, "Nome", "O nome é obrigatório")
            .IsNotNullOrEmpty(perfilUsuario.CPF, "CPF", "O CPF é obrigatório")
            .IsNotNullOrEmpty(perfilUsuario.Email, "Email", "O Email é obrigatório");
        }
    }
}
