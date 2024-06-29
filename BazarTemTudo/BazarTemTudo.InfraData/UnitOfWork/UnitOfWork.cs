using System.Transactions;
using IsolationLevel = System.Transactions.IsolationLevel;
using Flunt.Notifications;
using BazarTemTudo.InfraData.Context;

namespace BazarTemTudo.InfraData.UnitOfWork
{
    public class UnitOfWork : Notifiable<Notification>, IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private TransactionScope? _transaction;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }

            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            };

            _transaction = new TransactionScope(TransactionScopeOption.Required, options);
        }

        public void Commit()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction in progress.");
            }

            try
            {
                _context.SaveChanges();
                _transaction.Complete();
            }
            catch (Exception ex)
            {
                AddNotification("Commit", "Error committing transaction: " + ex.Message);
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Rollback()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction in progress.");
            }

            _transaction.Dispose();
            _transaction = null;
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                AddNotification("SaveChanges", "Não foi possível salvar as alterações no momento: " + ex.Message);
                throw;
            }
        }

        public TransactionScope GetTransaction()
        {
            if (_transaction == null)
            {
                BeginTransaction();
            }
            return _transaction;
        }
    }

}
