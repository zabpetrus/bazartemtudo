using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities._Base._Contracts
{
    public class ClientesContract : Contract<Clientes>
    {
        public ClientesContract(Clientes clientes) 
        {
            Requires();                 
        }
    }
}
