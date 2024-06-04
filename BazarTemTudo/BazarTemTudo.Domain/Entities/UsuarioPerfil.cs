using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class UsuarioPerfil
    {
        public string UserId { get; set; }
        public string ProfileName { get; set; }
        public string Description { get; set; }

    }
}
