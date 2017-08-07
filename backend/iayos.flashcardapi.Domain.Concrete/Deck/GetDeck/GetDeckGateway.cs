using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Deck.GetDeck;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Deck.GetDeck
{
	public class GetDeckGateway : FlashCardGateway, IGetDeckGateway, IFindDeckByNameFromMsSqlDb, IFindDeckByIdFromMsSqlDb
	{
		public GetDeckGateway(IDbConnection dbConnection) : base(dbConnection)
		{
		}

		public DeckModel GetDeckModelById(Guid deckId)
		{
			var deckModel = this.FindDeckById(deckId);
			if (deckModel == null) throw new Exception("NotFound");
			return deckModel;
		}

	}
}