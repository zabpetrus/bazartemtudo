using BazarTemTudo.Domain.Entities;
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
    public class CargaService : ICargaService
    {
        private readonly ICargaRepository _cargaRepository;

        public CargaService(ICargaRepository cargaRepository)
        {
            _cargaRepository = cargaRepository;
        }

        public void CreateMultiples(IEnumerable<Carga> entities)
        {
            _cargaRepository.CreateMultiples(entities);
        }

        public IEnumerable<Carga> GetAll()
        {
            return _cargaRepository.GetAll();
        }

        public bool TruncateCarga()
        {
            return _cargaRepository.TruncateCarga();
        }
    }
}
