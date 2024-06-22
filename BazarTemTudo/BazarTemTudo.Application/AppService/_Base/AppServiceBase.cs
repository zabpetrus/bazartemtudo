using AutoMapper;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Domain.Interface.Service._Base;
using Flunt.Notifications;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.AppService._Base
{
    public class AppServiceBase<VM, M> : IAppServiceBase<VM> where VM : class where M : class
    {
        private readonly IServiceBase<M> _serviceBase;
        private readonly IMapper _mapper;
        private readonly ILogger<AppServiceBase<VM, M>> _logger;

        public AppServiceBase(IServiceBase<M> serviceBase, IMapper mapper, ILogger<AppServiceBase<VM, M>> logger)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
            _logger = logger;
        }

        public void Add(VM obj)
        {
            try
            {
                var res = _mapper.Map<M>(obj);
                _serviceBase.Add(res);
            }
            catch (Exception ex)
            {
               throw new Exception(ex.ToString(), ex);
            }
        }

        public void AddRange(IEnumerable<VM> entities)
        {
            try
            {
                var all = _mapper.Map<List<M>>(entities);
                _serviceBase.AddRange(all);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public IEnumerable<VM> GetAll()
        {
            try
            {
               var res = _serviceBase.GetAll();
               return _mapper.Map<List<VM>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public VM GetById(long id)
        {
            try
            {

                var res = _serviceBase.GetById(id);
                return _mapper.Map<VM>(res);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

      
        public void RemoveById(long id)
        {
            try
            {
                var res = _serviceBase.RemoveById(id);
                if (!res) { throw new Exception("Não foi possivel excluir o registro!"); }             

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public void Update(long id, VM obj)
        {
            try
            {
                var res = _mapper.Map<M>(obj);
                _serviceBase.Update(id, res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }
    }
}
