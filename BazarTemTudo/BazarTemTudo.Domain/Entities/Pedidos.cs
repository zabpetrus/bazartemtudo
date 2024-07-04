using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Pedidos : Entity
    {
        
          public string Order_id { get; set; }

          public DateTime Purchase_Date {  get; set; }

          public DateTime Payments_Date { get; set; }

          public string Currency {  get; set; } 

          public string Ship_service_level {  get; set; }

          public StatusPedido statusPedido { get; set; } = StatusPedido.Pendente; 


          //Navegação

            public long ClientesId { get; set; }

            public Clientes Clientes { get; set; }

            public ICollection<ItensPedidos> ItensPedidos { get; set; }

            public long Endereco_Id { get; set; }    

            public Endereco Endereco { get; set; }


    }
}
