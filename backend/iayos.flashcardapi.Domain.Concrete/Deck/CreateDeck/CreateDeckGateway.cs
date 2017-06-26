using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Deck.CreateDeck
{
	public class CreateDeckGateway : FlashCardGateway, ICreateDeckGateway
	{
		public CreateDeckGateway(IDbConnection dbConnection) : base(dbConnection)
		{
		}


		public Guid Insert(DeckModel deck)
		{
			var table = deck.ToDeckTable();
			Db.Insert(table);
			return table.DeckId;
		}
	}
}