using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities.Enums;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.Domain.Interface.Repository._Base;
using BazarTemTudo.Domain.Interface.Service;
using BazarTemTudo.Domain.Service._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Domain.Service
{
    public class UsuarioInternoService : ServiceBase<UsuarioInterno>, IUsuarioInternoService
    {
        private readonly IUsuarioInternoRepository _usuarioInternoRepository;
        public UsuarioInternoService(IUsuarioInternoRepository Repository) : base(Repository)
        {
            _usuarioInternoRepository = Repository;
        }
    }
}
