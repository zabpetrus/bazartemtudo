using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities._Base
{
    public abstract class Entity : Notifiable<Notification>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            Data_Registro = DateTime.UtcNow;
            Data_Atualizacao = DateTime.Now;
        }

        [Key]
        public Guid Id { get; private set; }

        public DateTime Data_Registro { get; private set; }

        public DateTime Data_Atualizacao { get; private set; }


    }
}
