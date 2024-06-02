using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities._Base._Contracts
{
    public class EnderecoContract : Contract<Endereco>
    {
        public EnderecoContract(Endereco endereco)
        {
            Requires()
                .IsNotNullOrEmpty(endereco.Rua, "Rua", "Rua não pode estar em branco");
        }
    }
}
