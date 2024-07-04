using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.ViewModels
{
    public class DespachoMercadoriasViewModel
    {
        public StatusDespacho Status_Entrega { get; set; } = StatusDespacho.Em_processamento;

        public DateTime Data_Liberacao { get; set; } = DateTime.Now;


        //Navegação

        public long PedidoId { get; set; }

        public Pedidos Pedidos { get; set; }


        public Transportadoras Transportadora { get; set; }

        public long Transportadora_ID { get; set; }
    }
}
