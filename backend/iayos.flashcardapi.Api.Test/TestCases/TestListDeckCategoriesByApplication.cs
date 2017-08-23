using System;
using System.Collections.Generic;
using System.Linq;
using iayos.flashcardapi.Api.Test.Infrastructure;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.Domain.Dto.Application;
using iayos.flashcardapi.Domain.Dto.Deck;
using iayos.flashcardapi.ServiceModel.DeckCategory;
using ServiceStack.OrmLite;
using ShouldBeAssertions;
using Xunit;

namespace iayos.flashcardapi.Api.Test.TestCases
{
	public class TestListDeckCategoriesByApplication : FlashcardDataInjectorUnitTester
	{
		[Fact]
		public void ConfirmCanLoadDeckCategoriesByApplication()
		{
			var applicationId = InjectApplication(name: DateTime.Now.Ticks.ToString());
			var deckCategoryId2 = InjectDeckCategory(applicationId, name: "category 2");
			var deckCategoryId1 = InjectDeckCategory(applicationId, name: "category 1");
			
			var deckCategory1 = Db.SingleById<DeckCategoryTable>(deckCategoryId1);
			var deckCategory2 = Db.SingleById<DeckCategoryTable>(deckCategoryId2);

			var response = JsonServiceClient.Get(new ListDeckCategoriesByApplicationRequest { ApplicationId = applicationId });

			response.Results.First().ShouldLookLike(new DeckCategoryDto
			{
				DeckCategoryId = deckCategory1.DeckCategoryId,
				Name = deckCategory1.Name
			});
			response.Results.Skip(1).First().ShouldLookLike(new DeckCategoryDto
			{
				DeckCategoryId = deckCategory2.DeckCategoryId,
				Name = deckCategory2.Name
			});
		}


		[Fact]
		public void ConfirmCanLoadDeckCategoriesWithDecksByApplication()
		{
			var applicationId = InjectApplication(name: DateTime.Now.Ticks.ToString());
			var deckCategoryId2 = InjectDeckCategory(applicationId, name: "category 2");
			var dc2Deck2Id = InjectDeck(applicationId, deckCategoryId2, "deck 2");
			var dc2Deck1Id = InjectDeck(applicationId, deckCategoryId2, "deck 1");
			var deckCategoryId1 = InjectDeckCategory(applicationId, name: "category 1");
			var dc1Deck2Id = InjectDeck(applicationId, deckCategoryId1, "deck 2");
			var dc1Deck1Id = InjectDeck(applicationId, deckCategoryId1, "deck 1");

			var deckCategory1 = Db.LoadSingleById<DeckCategoryTable>(deckCategoryId1, x => x.Decks);
			var deckCategory2 = Db.LoadSingleById<DeckCategoryTable>(deckCategoryId2, x => x.Decks);

			var response = JsonServiceClient.Get(new ListDeckCategoriesByApplicationRequest { ApplicationId = applicationId, IncludeDecks = true});

			response.Results.First().ShouldLookLike(new DeckCategoryDto
			{
				DeckCategoryId = deckCategory1.DeckCategoryId,
				Name = deckCategory1.Name,
				Decks = new List<DeckDto>
				{
					new DeckDto
					{
						DeckId = deckCategory1.Decks.Single(d => d.DeckId == dc1Deck1Id).DeckId,
						Name = deckCategory1.Decks.Single(d => d.DeckId == dc1Deck1Id).Name,
						FrontLanguage = deckCategory1.Decks.Single(d => d.DeckId == dc1Deck1Id).FrontLanguage,
						BackLanguage = deckCategory1.Decks.Single(d => d.DeckId == dc1Deck1Id).BackLanguage
					},
					new DeckDto
					{
						DeckId = deckCategory1.Decks.Single(d => d.DeckId == dc1Deck2Id).DeckId,
						Name = deckCategory1.Decks.Single(d => d.DeckId == dc1Deck2Id).Name,
						FrontLanguage = deckCategory1.Decks.Single(d => d.DeckId == dc1Deck2Id).FrontLanguage,
						BackLanguage = deckCategory1.Decks.Single(d => d.DeckId == dc1Deck2Id).BackLanguage
					}
				}
			});
			response.Results.Skip(1).First().ShouldLookLike(new DeckCategoryDto
			{
				DeckCategoryId = deckCategory2.DeckCategoryId,
				Name = deckCategory2.Name,
				Decks = new List<DeckDto>
				{
					new DeckDto
					{
						DeckId = deckCategory2.Decks.Single(d => d.DeckId == dc2Deck1Id).DeckId,
						Name = deckCategory2.Decks.Single(d => d.DeckId == dc2Deck1Id).Name,
						FrontLanguage = deckCategory2.Decks.Single(d => d.DeckId == dc2Deck1Id).FrontLanguage,
						BackLanguage = deckCategory2.Decks.Single(d => d.DeckId == dc2Deck1Id).BackLanguage
					},
					new DeckDto
					{
						DeckId = deckCategory2.Decks.Single(d => d.DeckId == dc2Deck2Id).DeckId,
						Name = deckCategory2.Decks.Single(d => d.DeckId == dc2Deck2Id).Name,
						FrontLanguage = deckCategory2.Decks.Single(d => d.DeckId == dc2Deck2Id).FrontLanguage,
						BackLanguage = deckCategory2.Decks.Single(d => d.DeckId == dc2Deck2Id).BackLanguage
					}
				}
			});
		}
	}


	
}
