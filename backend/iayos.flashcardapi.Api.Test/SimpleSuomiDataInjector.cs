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

			Fixture.Customize<DeckTable>(obj => obj
				.With(x => x.DeckId)
				.Without(x => x.ApplicationId)
				.Without(x => x.Application)
				.Without(x => x.Cards)
			);

			Fixture.Customize<CardTable>(obj => obj
				.With(x => x.CardId)
				.Without(x => x.DeckId)
				.Without(x => x.Deck)
				.Without(x => x.Order)
			);
		}

		protected Guid InjectApplication()
		{
			var application = Fixture.Create<ApplicationTable>();
			Db.Insert(application);
			return application.ApplicationId;
		}

		protected Guid InjectCard(Guid? deckId = null)
		{
			var card = Fixture.Create<CardTable>();
			card.DeckId = deckId ?? InjectDeck();
			Db.Insert(card);
			return card.CardId;
		}

		protected Guid InjectDeck(Guid? applicationId = null)
		{
			var deck = Fixture.Create<DeckTable>();
			deck.ApplicationId = applicationId ?? InjectApplication();
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