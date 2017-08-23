using System;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using Ploeh.AutoFixture;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Api.Test.Infrastructure
{
	public class FlashcardDataInjectorUnitTester : FlashcardApiUnitTester
	{
		/// <summary>
		///     Fixture used to generate randomised test data
		/// </summary>
		protected Fixture DataGenerator = new Fixture();


		public FlashcardDataInjectorUnitTester()
		{
			CustomizeTheAutoFixtureInstance();
		}

		private void CustomizeTheAutoFixtureInstance()
		{
			// Make Guids be generated according to the selected, injected Sequential Guid generation strategy
			DataGenerator.Register(() => DbGuidGenerator.NewSequentialGuid());

			DataGenerator.Customize<ApplicationTable>(obj => obj
				.With(x => x.ApplicationId)
				.With(x => x.IsDeleted, false)
				.Without(x => x.Decks)
				.Without(x => x.DeckCategories)
			);

			DataGenerator.Customize<DeckCategoryTable>(obj => obj
				.With(x => x.DeckCategoryId)
				.With(x => x.IsDeleted, false)
				.Without(x => x.Application)
				.Without(x => x.ApplicationId)
				.Without(x => x.Decks)
			);


			DataGenerator.Customize<DeckTable>(obj => obj
				.With(x => x.DeckId)
				.With(x => x.IsDeleted, false)
				.Without(x => x.Application)
				.Without(x => x.ApplicationId)
				.Without(x => x.Cards)
				.Without(x => x.DeckCategory)
				.Without(x => x.DeckCategoryId)
			);

			DataGenerator.Customize<CardTable>(obj => obj
				.With(x => x.CardId)
				.With(x => x.IsDeleted, false)
				.Without(x => x.Deck)
				.Without(x => x.DeckId)
				.Without(x => x.Order)
			);
		}


		protected Guid InjectApplication(string name = null)
		{
			var application = DataGenerator.Create<ApplicationTable>();
			application.Name = name ?? application.Name;
			Db.Insert(application);
			return application.ApplicationId;
		}


		protected Guid InjectCard(Guid? deckId = null)
		{
			var card = DataGenerator.Create<CardTable>();
			card.DeckId = deckId ?? InjectDeck();
			Db.Insert(card);
			return card.CardId;
		}

		protected Guid InjectDeck(Guid? applicationId = null, Guid? deckCategoryId = null, string name = null)
		{
			var deck = DataGenerator.Create<DeckTable>();
			deck.ApplicationId = applicationId ?? InjectApplication();
			deck.DeckCategoryId = deckCategoryId ?? InjectDeckCategory(deck.ApplicationId);
			deck.Name = name ?? deck.Name;
			Db.Insert(deck);
			return deck.DeckId;
		}

		protected Guid InjectDeckCategory(Guid? applicationId = null, string name = null)
		{
			var deckCategoryTable = DataGenerator.Create<DeckCategoryTable>();
			deckCategoryTable.ApplicationId = applicationId ?? InjectApplication();
			deckCategoryTable.Name = name ?? deckCategoryTable.Name;
			Db.Insert(deckCategoryTable);
			return deckCategoryTable.DeckCategoryId;
		}

		protected Guid InjectUser()
		{
			var user = DataGenerator.Create<UserTable>();
			Db.Insert(user);
			return user.UserId;
		}
	}
}
