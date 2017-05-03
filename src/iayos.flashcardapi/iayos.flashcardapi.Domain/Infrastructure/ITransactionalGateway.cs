namespace iayos.flashcardapi.Domain.Infrastructure
{
	public interface ITransactionalGateway
	{
		void BeginTransaction();

		void CommitTransaction();

		void RollbackTransaction();
	}
}