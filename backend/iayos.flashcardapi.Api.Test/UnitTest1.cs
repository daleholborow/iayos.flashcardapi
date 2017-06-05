using iayos.flashcardapi.DomainModel.Flags;
using iayos.flashcardapi.DomainModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iayos.flashcardapi.Api.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{

			var repo = new IayosRepository();

			var applicationModel = new ApplicationModel
			{
				Name = "SimpleSuomi"
			};
			repo.Save(applicationModel);

			var topVerbsDeck = new DeckModel { Name = "Top Verbs", FrontLanguage = LanguageFlag.ENGLISH, BackLanguage = LanguageFlag.FINNISH };
			repo.Save(topVerbsDeck);
			ModelLinker.LinkOneToOne(applicationModel, am => am.Decks, topVerbsDeck, d => d.Application);

			for (var i = 0; i < 20; i++)
			{
				var card = new CardModel { Order = i+1, FrontText = "Front"+1, BackText = "Back"+i };
				repo.Save(card);
				ModelLinker.LinkOneToOne(topVerbsDeck, d => d.Cards, card, c => c.Deck);
			}

			var kitchenDeck = new DeckModel { Name = "Kitchen Items", FrontLanguage = LanguageFlag.ENGLISH, BackLanguage = LanguageFlag.FINNISH };
			repo.Save(kitchenDeck);
			ModelLinker.LinkOneToOne(applicationModel, am => am.Decks, kitchenDeck, d => d.Application);


		}
	}
}
