using System;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Api.Test
{
	public class SimpleSuomiDataInjector : TestingContext
	{

		public SimpleSuomiDataInjector()
		{
			CustomizeTheAutoFixtureInstance();
		}

		private void CustomizeTheAutoFixtureInstance()
		{
			Fixture.Customize<Guid>(obj => obj
				.With(x => x, DbGuidGenerator.NewSequentialGuid())
			);

			Fixture.Customize<ApplicationTable>(obj => obj
				.With(x => x.ApplicationId)
			);
		}

		protected Guid InjectApplication()
		{

			//Db.Insert()
				throw new NotImplementedException();
		}

		protected Guid InjectCard()
		{
			throw new NotImplementedException();
		}

		protected Guid InjectDeck()
		{
			throw new NotImplementedException();
		}

		protected Guid InjectUser()
		{
			throw new NotImplementedException();
		}

	}
}