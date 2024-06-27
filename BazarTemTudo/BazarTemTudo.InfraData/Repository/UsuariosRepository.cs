using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Entities.Enums;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.InfraData.Context;
using BazarTemTudo.InfraData.Repository._Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Repository
{
    public class UsuariosRepository : RepositoryBase<Usuarios>, IUsuarioRepository
    {
        public UsuariosRepository(ApplicationDBContext context) : base(context)
        {
        }
    }

}
