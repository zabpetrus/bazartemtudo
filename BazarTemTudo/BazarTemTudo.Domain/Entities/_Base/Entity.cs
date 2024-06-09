﻿using Flunt.Notifications;
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
            Not_Id = Guid.NewGuid();
            Data_Registro = DateTime.UtcNow;
            Data_Atualizacao = DateTime.Now;
        }

       
        public Guid Not_Id { get; private set; }

        [Key]
        public int? Id {  get; set; }

        public DateTime Data_Registro { get; private set; }

        public DateTime Data_Atualizacao { get; private set; }


    }
}