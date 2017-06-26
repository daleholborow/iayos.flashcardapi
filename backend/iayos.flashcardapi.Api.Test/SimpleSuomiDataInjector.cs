using System;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using Ploeh.AutoFixture;
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
				.Without(x => x.Decks)
			);
		}

		protected Guid InjectApplication()
		{
			var application = Fixture.Create<ApplicationTable>();
			Db.Insert(application);
			return application.ApplicationId;
		}

		protected Guid InjectCard()
		{
			var card = Fixture.Create<CardTable>();
			Db.Insert(card);
			return card.CardId;
		}

		protected Guid InjectDeck()
		{
			var deck = Fixture.Create<DeckTable>();
			Db.Insert(deck);
			return deck.DeckId;
		}

		protected Guid InjectUser()
		{
			var user = Fixture.Create<UserTable>();
			Db.Insert(user);
			return user.UserId;
		}

	}
}