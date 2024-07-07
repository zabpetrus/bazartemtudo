using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.CrossCutting.Service
{
    public class ConsultaDTO
    {
       public long ItemPedidoId { get; set; }
       public long PedidoId {  get; set; }
       public long ProdutoId { get; set; }
       public int  QuantidadeComprada { get; set; }                             
       public bool Disponivel {  get; set; }                                
       public decimal Soma {  get; set; }  
       public DateTime Prioridade {  get; set; }
    }
}
