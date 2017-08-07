using System.Data;
using iayos.sequentialguid;

namespace iayos.flashcardapi.Domain.Concrete
{

	public abstract class FlashCardGateway : IHasDbConnection, IHasSequentialGuidGenerator
	{
		protected FlashCardGateway(IDbConnection dbConnection, ISequentialGuidGenerator guidGenerator)
		{
			Db = dbConnection;
			GuidGenerator = guidGenerator;
		}

		public IDbConnection Db { get; }

		public ISequentialGuidGenerator GuidGenerator { get; }
	}
}