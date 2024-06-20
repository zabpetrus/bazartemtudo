﻿using BazarTemTudo.Domain.Entities;
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
    public class CargaService : ServiceBase<Carga>, ICargaService
    {
        private readonly ICargaRepository _cargaRepository;
        public CargaService(ICargaRepository Repository) : base(Repository)
        {
            _cargaRepository = Repository;
        }
    }
}