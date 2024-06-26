using System.Transactions;

namespace VEL.Infra.Data.UnitWork
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
