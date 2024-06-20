using BazarTemTudo.Domain.Entities._Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Perfil: Entity 
    {
       
        public string Nome { get; set; }

        public string Descricao { get; set; }  
        
        public Perfil()
        {
        }

    }
}
