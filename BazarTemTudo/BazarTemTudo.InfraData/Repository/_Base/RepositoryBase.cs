using BazarTemTudo.Domain.Entities._Base;
using BazarTemTudo.Domain.Interface.Repository._Base;
using BazarTemTudo.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Linq.Expressions;


namespace BazarTemTudo.InfraData.Repository._Base
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        protected readonly ApplicationDBContext _context;

        private bool _disposed = false;

        public RepositoryBase(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao criar objeto: " + ex.Message);
            }

        }



        public void CreateMultiples(IEnumerable<T> entities)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                _context.Set<T>().AddRange(entities);
                _context.SaveChanges();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao criar múltiplos objeto: " + ex.Message);
            }
        }

        public void Delete(T entity)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao excluir objeto: " + ex.Message);
            }
        }

        public void DeleteMultiples(IEnumerable<T> entities)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.RemoveRange(entities);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao excluir múltiplos objetos: " + ex.Message);
            }
        }

        public IEnumerable<T> GetAll()
        {
            var res = _context.Set<T>().ToList();

            if (res == null)
            {
                throw new Exception("Not Found");
            }
            return res;
        }

        public T GetById(long id)
        {
            var res = _context.Set<T>().Find(id);

            if (res == null)
            {
                throw new Exception("Not Found");
            }
            return res;
        }

        public T Search(string expression)
        {
            try
            {
                var query = _context.Set<T>().AsQueryable();

                var parameter = Expression.Parameter(typeof(T), "e");
                Expression predicate = Expression.Constant(false);

                var properties = typeof(T).GetProperties()
                    .Where(p => p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propertyExpression = Expression.Property(parameter, property);
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                    if (containsMethod != null)
                    {
                        var someValue = Expression.Constant(expression, typeof(string));
                        var containsExpression = Expression.Call(propertyExpression, containsMethod, someValue);
                        predicate = Expression.OrElse(predicate, containsExpression);
                    }

                }

                var lambda = Expression.Lambda<Func<T, bool>>(predicate, parameter);
                query = query.Where(lambda);

                var res = query.FirstOrDefault();
                if (res == null)
                {
                    throw new Exception("res null");
                }
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while counting entities: " + ex.Message, ex);
            }
        }

        public List<T> SearchAll(string expression)
        {
            try
            {
                var query = _context.Set<T>().AsQueryable();

                var properties = typeof(T).GetProperties()
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
            };
        }

        public void Update(long Id, T entity)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var existingEntity = _context.Set<T>().Find(Id);
                if (existingEntity == null)
                {
                    throw new Exception($"Entidade com Id {Id} não encontrada.");
                }

                var entityEntry = _context.Entry(existingEntity);
                var entityProperties = entityEntry.Properties.ToDictionary(p => p.Metadata.Name, p => p);

                // Atualiza apenas as propriedades que não são chaves
                foreach (var property in typeof(T).GetProperties())
                {
                    if (entityProperties.ContainsKey(property.Name))
                    {
                        var propertyEntry = entityProperties[property.Name];
                        var propertyMetaData = propertyEntry.Metadata;

                        if (!propertyMetaData.IsPrimaryKey() && !propertyMetaData.IsForeignKey())
                        {
                            var newValue = property.GetValue(entity);
                            propertyEntry.CurrentValue = newValue;
                            propertyEntry.IsModified = true;
                        }
                    }
                }

                bool saveFailed;
                do
                {
                    saveFailed = false;
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        var dbEntry = ex.Entries.Single();
                        var clientValues = (T)dbEntry.Entity;
                        var databaseEntry = dbEntry.GetDatabaseValues();
                        if (databaseEntry == null)
                        {
                            throw new Exception("Unable to save changes. The entity was deleted by another user.");
                        }
                        var databaseValues = (T)databaseEntry.ToObject();

                        foreach (var property in dbEntry.Metadata.GetProperties())
                        {
                            var proposedValue = dbEntry.Property(property.Name).CurrentValue;
                            var databaseValue = databaseEntry.GetValue<object>(property);

                            // Resolver conflitos (exemplo: mantendo valor do cliente)
                            dbEntry.Property(property.Name).CurrentValue = proposedValue;
                        }

                        dbEntry.OriginalValues.SetValues(databaseEntry);
                    }
                } while (saveFailed);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro durante o procedimento: " + ex.Message, ex);
            }
        }


        public void UpdateMultiples(IEnumerable<T> entities)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.UpdateRange(entities);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao atualizar múltiplas entidades: " + ex.Message);
            }
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }
            _disposed = true;
        }

        public T GetById(object id)
        {
            try
            {
               return _context.Find<T>(id);   

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var existingEntity = _context.Set<T>().Find(id);
                _context.Remove(existingEntity);
                return true;    


            }
            catch (Exception ex)
            {
                 throw new Exception (ex.Message, ex);  
            }
        }

        int IRepositoryBase<T>.Search(string expression)
        {
            var entities = _context.Set<T>().FromSqlRaw(expression).ToList();
            return entities.Count;

        }

        public long GetID(T entity)
        {
            try
            {
                var foundEntity = _context.Find<T>(entity);

                if (foundEntity != null)
                {
                    var idProperty = typeof(T).GetProperty("Id");

                    if (idProperty != null)
                    {
                        return (long)idProperty.GetValue(foundEntity);
                    }
                    else
                    {
                        throw new InvalidOperationException("A entidade não possui uma propriedade 'Id' válida.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Entidade não encontrada para obter o ID.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a procura do ID.", ex);
            }
        }


        public IEnumerable<T> FindAll(T args)
        {
            return _context.Set<T>().ToList();  
        }

        public T Find(T entity)
        {
            try
            {
                var entityType = _context.Model.FindEntityType(typeof(T));

                if (entityType == null)
                {
                    throw new Exception("Tipo de entidade não encontrado no contexto.");
                }

                var primaryKey = entityType.FindPrimaryKey();

                if (primaryKey == null)
                {
                    throw new Exception("Chave primária não definida para o tipo de entidade.");
                }

                var keyValues = primaryKey.Properties.Select(x => typeof(T).GetProperty(x.Name).GetValue(entity)).ToArray();

                var foundEntity = _context.Set<T>().Find(keyValues);

                if (foundEntity == null)
                {
                    throw new Exception("Entidade não encontrada na base de dados.");
                }

                return foundEntity;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a busca da entidade: " + ex.Message, ex);
            }
        }

        public long CreateGetID(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();

                // Obter informações sobre a chave primária da entidade
                var entityType = _context.Model.FindEntityType(typeof(T));

                if(entityType == null)
                {
                    throw new ArgumentNullException(nameof(entityType));
                }

                var primaryKey = entityType.FindPrimaryKey();

                if (primaryKey == null)
                {
                    throw new InvalidOperationException("A entidade não possui uma chave primária definida.");
                }

                // Verificar se a chave primária possui exatamente uma propriedade
                if (primaryKey.Properties.Count != 1)
                {
                    throw new InvalidOperationException("A chave primária da entidade não é simples (não possui exatamente uma propriedade).");
                }

                // Obter o nome da propriedade que representa a chave primária
                var primaryKeyPropertyName = primaryKey.Properties[0].Name;

                // Acessar o valor da propriedade que representa a chave primária
                var propertyInfo = entity.GetType().GetProperty(primaryKeyPropertyName);
                if (propertyInfo == null)
                {
                    throw new InvalidOperationException($"A propriedade '{primaryKeyPropertyName}' não foi encontrada na entidade '{typeof(T).Name}'.");
                }

                var primaryKeyValue = (long)propertyInfo.GetValue(entity);

                return primaryKeyValue;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir a entidade e retornar o ID", ex);
            }
        }
    }
}
