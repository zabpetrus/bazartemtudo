using AutoMapper;
using BazarTemTudo.Application.AppService._Base;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Interface.Service;
using BazarTemTudo.Domain.Interface.Service._Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.AppService
{
    public class UsuariosAppService : AppServiceBase<UsuariosViewModel, Usuarios>, IUsuariosAppService
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosAppService(IUsuarioService serviceBase, IMapper mapper, ILogger<AppServiceBase<UsuariosViewModel, Usuarios>> logger) : base(serviceBase, mapper, logger)
        {
            _usuarioService = serviceBase;  
        }
    }
}
