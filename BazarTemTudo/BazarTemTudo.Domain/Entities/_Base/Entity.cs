using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities._Base
{
    public abstract class Entity : Notifiable<Notification>
    {
        protected Entity()
        {
            Not_Id = Guid.NewGuid();
            Data_Registro = DateTime.UtcNow;
            Data_Atualizacao = DateTime.Now;
        }

        [NotMapped]
        public Guid Not_Id { get; private set; }

        [Key]
        public long? Id {  get; set; }

        public DateTime Data_Registro { get; private set; } = DateTime.Now;

        public DateTime Data_Atualizacao { get; private set; } = DateTime.Now;


    }
}
