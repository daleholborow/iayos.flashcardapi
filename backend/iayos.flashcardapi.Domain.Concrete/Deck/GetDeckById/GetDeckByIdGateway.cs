using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Deck.GetDeckById;
using iayos.flashcardapi.DomainModel.Models;
using iayos.sequentialguid;

namespace iayos.flashcardapi.Domain.Concrete.Deck.GetDeckById
{
	public class GetDeckByIdGateway : FlashCardGateway, IGetDeckByIdGateway, IFindDeckByNameFromMsSqlDb, IFindDeckByIdFromMsSqlDb
	{
		public GetDeckByIdGateway(IDbConnection dbConnection, ISequentialGuidGenerator guidGenerator) : base(dbConnection, guidGenerator)
		{
		}

		public DeckModel GetDeckById(Guid deckId)
		{
			var deckModel = this.FindDeckById(deckId);
			if (deckModel == null) throw new Exception("NotFound");
			return deckModel;
		}

	}
}
 