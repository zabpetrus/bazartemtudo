using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Usuarios : IdentityUser
    {
       
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }

    }
}
