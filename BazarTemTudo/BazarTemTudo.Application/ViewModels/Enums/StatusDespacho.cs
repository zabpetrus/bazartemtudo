using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels.Enums
{
    public enum StatusDespacho
    {
        Pendente = 1,
        Em_processamento = 2,
        Pronto_para_envio = 3,
        Entregue = 4,
        Cancelado = 5
    }
}
