﻿using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.Interface
{
    public interface IEstoqueAppService : IAppServiceBase<EstoqueViewModel>
    {
        public EstoqueViewModel GetByProductId(long productId);
    }
}
