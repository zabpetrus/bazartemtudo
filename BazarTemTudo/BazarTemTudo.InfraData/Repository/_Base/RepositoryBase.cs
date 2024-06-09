using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.Domain.Interface.Repository._Base;
using BazarTemTudo.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Repository._Base
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : Entity
    {

        private readonly SQLiteContext _context;

        public RepositoryBase(SQLiteContext context)
        {
            _context = context;
        }

      
      
        public void Create(TEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel inserir o usuario: " + ex);
            }
        }

        public void CreateMultiples(IEnumerable<TEntity> entities)
        {
            try
            {
                _context.AddRange(entities);    
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel inserir o usuario: " + ex);
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Houve um erro na requisicao" + ex);
            }
        }

        public void DeleteMultiples(IEnumerable<TEntity> entities)
        {
            try
            {
                _context.RemoveRange(entities); 
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel inserir o usuario: " + ex);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

     

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>().ToList();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro na requisicao" + ex);
            }
        }

        

        public TEntity GetById(object id)
        {
            try
            {
                var res = _context.Set<TEntity>().Find(id);

                if (res == null)
                {
                    throw new Exception("Not Found");
                }
                return res;

            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro na requisicao" + ex);
            }
        }

        public int Search(string expression)
        {
            try
            {
                var query = _context.Set<TEntity>().AsQueryable();

                var parameter = Expression.Parameter(typeof(TEntity), "e");
                Expression predicate = Expression.Constant(false);

                var properties = typeof(TEntity).GetProperties()
                    .Where(p => p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propertyExpression = Expression.Property(parameter, property);
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                    if(containsMethod != null)
                    {
                        var someValue = Expression.Constant(expression, typeof(string));
                        var containsExpression = Expression.Call(propertyExpression, containsMethod, someValue);
                        predicate = Expression.OrElse(predicate, containsExpression);
                    }
                   
                }

                var lambda = Expression.Lambda<Func<TEntity, bool>>(predicate, parameter);
                query = query.Where(lambda);

                return query.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while counting entities: " + ex.Message, ex);
            }
        }

        public List<TEntity> SearchAll(string expression)
        {
            try
            {
                var query = _context.Set<TEntity>().AsQueryable();

                var properties = typeof(TEntity).GetProperties()
                    .Where(p => p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var opt = 
                    query = query.Where(e => EF.Functions.Like((string?)property.GetValue(e), $"%{expression}%"));
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while searching for entities: " + ex.Message, ex);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel inserir o usuario: " + ex);
            }
        }

        public void UpdateMultiples(IEnumerable<TEntity> entities)
        {
            try
            {
                _context.UpdateRange(entities);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel inserir o usuario: " + ex);
            }
        }
    }


}
