﻿using BazarTemTudo.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class UsuarioExterno : Usuarios
    {
        public TipoUsuario TipoUsuario { get; set; } = TipoUsuario.Externo;

    }
}
