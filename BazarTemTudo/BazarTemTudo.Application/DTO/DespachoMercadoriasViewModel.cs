using BazarTemTudo.Application.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.DTO
{
    public class DespachoMercadoriasViewModel
    {
        public int Transportadora_ID { get; set; }

        public TransportadorasViewModel Transportadora { get; set; } = new TransportadorasViewModel();

        public StatusDespacho Status_Entrega { get; set; }

        public DateTime Data_Liberacao { get; set; }

        public DespachoMercadoriasViewModel(int transportadora_ID, TransportadorasViewModel transportadora, StatusDespacho status_Entrega, DateTime data_Liberacao)
        {
            Transportadora_ID = transportadora_ID;
            Transportadora = transportadora;
            Status_Entrega = status_Entrega;
            Data_Liberacao = data_Liberacao;
        }

        public DespachoMercadoriasViewModel()
        {
        }
    }
}
