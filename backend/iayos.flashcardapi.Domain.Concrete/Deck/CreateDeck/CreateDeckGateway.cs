using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck;
using iayos.flashcardapi.DomainModel.Models;
using iayos.sequentialguid;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Deck.CreateDeck
{
	public class CreateDeckGateway : FlashCardGateway, ICreateDeckGateway
	{
		public CreateDeckGateway(IDbConnection dbConnection, ISequentialGuidGenerator guidGenerator) : base(dbConnection, guidGenerator)
		{
		}


		public Guid Insert(DeckModel deck)
		{
			deck.DeckId = GuidGenerator.NewSequentialGuid();
			var table = deck.ToDeckTable();
			Db.Insert(table);
			return table.DeckId;
		}
	}
}