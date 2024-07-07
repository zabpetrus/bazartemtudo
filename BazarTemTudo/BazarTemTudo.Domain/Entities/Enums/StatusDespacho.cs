using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities.Enums
{
    public enum StatusDespacho
    {
        Em_processamento = 1,
		Pronto_para_envio = 2,
		Entregue = 3,
		Cancelado = 4
    }
}
