using System.Transactions;

namespace BazarTemTudo.InfraData.UnitOfWork
{
    public interface IUnitOfWork
    {
        TransactionScope GetTransaction();
        void BeginTransaction();
        void Commit();
        void Rollback();
        void SaveChanges();

    }
}
