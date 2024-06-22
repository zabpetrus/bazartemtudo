﻿using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.Interface
{
    public interface ICargaAppService : IAppServiceBase<CargaViewModel>
    {
        //Exclusivo de carga... Não precisa ser repetido para as outras...
      
    }
}
