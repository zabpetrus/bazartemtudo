﻿using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities._Base._Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Clientes : Entity
    {
        public string Nome { get; set; } = String.Empty;

        public string CPF { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Phone { get; set; }   = String.Empty ;


        // Propriedade de navegação para os pedidos associados a este cliente
        public ICollection<Pedidos> Pedidos { get; set; }

    }
}
