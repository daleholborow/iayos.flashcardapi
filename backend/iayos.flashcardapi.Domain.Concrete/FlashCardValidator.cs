using System.Data;
using iayos.flashcardapi.Domain.Concrete.Application;

namespace iayos.flashcardapi.Domain.Concrete
{
	public abstract class FlashCardValidator : IHasDbConnection
	{
		protected FlashCardValidator(IDbConnection dbConnection)
		{
			Db = dbConnection;
		}

		public IDbConnection Db { get; }
	}
}