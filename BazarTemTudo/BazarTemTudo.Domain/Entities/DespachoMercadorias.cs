using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class DespachoMercadorias : Entity
    {
        public  int Transportadora_ID { get; set; }

        public Transportadoras Transportadora {  get; set; }  = new Transportadoras();

        public StatusDespacho Status_Entrega {  get; set; } 

        public DateTime Data_Liberacao { get; set; }

        public DespachoMercadorias(int transportadora_ID, Transportadoras transportadora, StatusDespacho status_Entrega, DateTime data_Liberacao)
        {
            Transportadora_ID = transportadora_ID;
            Transportadora = transportadora;
            Status_Entrega = status_Entrega;
            Data_Liberacao = data_Liberacao;
        }

        public DespachoMercadorias()
        {
        }
    }
}
