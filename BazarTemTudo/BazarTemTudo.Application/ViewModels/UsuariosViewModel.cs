using BazarTemTudo.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class UsuariosViewModel
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public  TipoUsuario TipoUsuario { get; set; }


    }
}
