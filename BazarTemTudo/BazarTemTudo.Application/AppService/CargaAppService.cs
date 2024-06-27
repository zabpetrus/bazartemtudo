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
    public class CargaAppService : ICargaAppService
    {
        private readonly ICargaService _cargaService;
        private readonly IMapper _mapper;

        public CargaAppService(ICargaService cargaService, IMapper mapper)
        {
            _cargaService = cargaService;
            _mapper = mapper;
        }

   
        public void CreateMultiples(IEnumerable<CargaViewModel> entities)
        {
            var result = _mapper.Map<List<Carga>>(entities);
            _cargaService.CreateMultiples(result);
        }

        public IEnumerable<CargaViewModel> GetAll()
        {
           var res = _cargaService.GetAll();
            return _mapper.Map<List<CargaViewModel>>(res);  
        }

        public bool TruncateCarga()
        {
           return _cargaService.TruncateCarga();
        }
    }
}
