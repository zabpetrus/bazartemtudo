using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Entities
{
    public class Usuarios : IdentityUser{
       
        public Usuarios()
        {
        }

        public Usuarios(string nome, string cpf, string email, TipoUsuario tipoUsuario)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            TipoUsuario = tipoUsuario;
        }

        public string Nome { get; set; }

        public string Cpf { get; set; }


        public virtual TipoUsuario TipoUsuario { get; set; }


        public override bool Equals(object? obj)
        {
            return obj is Usuarios usuarios &&
                   Id == usuarios.Id &&
                   UserName == usuarios.UserName &&
                   NormalizedUserName == usuarios.NormalizedUserName &&
                   Email == usuarios.Email &&
                   NormalizedEmail == usuarios.NormalizedEmail &&
                   EmailConfirmed == usuarios.EmailConfirmed &&
                   PasswordHash == usuarios.PasswordHash &&
                   SecurityStamp == usuarios.SecurityStamp &&
                   ConcurrencyStamp == usuarios.ConcurrencyStamp &&
                   PhoneNumber == usuarios.PhoneNumber &&
                   PhoneNumberConfirmed == usuarios.PhoneNumberConfirmed &&
                   TwoFactorEnabled == usuarios.TwoFactorEnabled &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(LockoutEnd, usuarios.LockoutEnd) &&
                   LockoutEnabled == usuarios.LockoutEnabled &&
                   AccessFailedCount == usuarios.AccessFailedCount &&
                   Nome == usuarios.Nome &&
                   Cpf == usuarios.Cpf &&
                   Email == usuarios.Email &&
                   TipoUsuario == usuarios.TipoUsuario;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(UserName);
            hash.Add(NormalizedUserName);
            hash.Add(Email);
            hash.Add(NormalizedEmail);
            hash.Add(EmailConfirmed);
            hash.Add(PasswordHash);
            hash.Add(SecurityStamp);
            hash.Add(ConcurrencyStamp);
            hash.Add(PhoneNumber);
            hash.Add(PhoneNumberConfirmed);
            hash.Add(TwoFactorEnabled);
            hash.Add(LockoutEnd);
            hash.Add(LockoutEnabled);
            hash.Add(AccessFailedCount);
            hash.Add(Nome);
            hash.Add(Cpf);
            hash.Add(Email);
            hash.Add(TipoUsuario);
            return hash.ToHashCode();
        }
    }
}
