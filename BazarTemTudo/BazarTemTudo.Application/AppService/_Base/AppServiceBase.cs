using AutoMapper;
using BazarTemTudo.Application.Interface._Base;
using BazarTemTudo.Domain.Entities._Base;
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
        

        public long CreateGetID(VM entity)
        {
            try
            {
                var all = _mapper.Map<M>(entity);
                return _serviceBase.CreateGetID(all);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public void CreateMultiples(IEnumerable<VM> entities)
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

        public bool Delete(long id)
        {
            try
            {                 
              return _serviceBase.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public void DeleteMultiples(IEnumerable<VM> entities)
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


        public IEnumerable<VM> FindAll(VM args)
        {
            try
            {
                var mappedEntities = _mapper.Map<M>(args); // Mapeia args para o tipo M

                var allEntities = _serviceBase.FindAll(mappedEntities); // Busca todas as entidades de tipo M

                var mappedViewModels = _mapper.Map<IEnumerable<VM>>(allEntities); // Mapeia as entidades de tipo M para ViewModels VM

                return mappedViewModels; // Retorna as entidades mapeadas para ViewModels
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todos os elementos mapeados", ex);
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

      

        public long GetID(VM entity)
        {
             try
             {
                 var e = _mapper.Map<M>(entity);
                return _serviceBase.GetID(e);
             }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        
        public int Search(string expression)
        {
            try
            {
                var res = _serviceBase.Search(expression);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a pesquisa", ex);
            }
        }


        public List<VM> SearchAll(string expression)
        {
           var s = _serviceBase.SearchAll(expression); 
           return _mapper.Map<List<VM>>(s);   
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

        public void UpdateMultiples(IEnumerable<VM> entities)
        {
            _serviceBase.UpdateMultiples(_mapper.Map<IEnumerable<M>>(entities));   
        }


    }
}
