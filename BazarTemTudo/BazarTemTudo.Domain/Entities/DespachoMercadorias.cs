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
                
         public long Pedido_Id { get; set; }

         public  long Transportadora_ID { get; set; } 

        public StatusDespacho Status_Entrega {  get; set; } 

        public DateTime Data_Liberacao { get; set; } = DateTime.Now;


        //Navegação

       

        public Pedidos Pedidos { get; set; }


        public Transportadoras Transportadora { get; set; }

        

      
    }
}
