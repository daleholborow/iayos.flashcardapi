using System.Data;

namespace iayos.flashcardapi.Domain.Concrete
{
	public abstract class FlashCardGateway : IHasDbConnection
	{
		protected FlashCardGateway(IDbConnection dbConnection)
		{
			Db = dbConnection;
		}

		public IDbConnection Db { get; }
	}
}