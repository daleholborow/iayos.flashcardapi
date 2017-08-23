using System;
using System.Data;
using iayos.flashcardapi.Domain.Concrete.Deck;
using iayos.flashcardapi.DomainModel.Models;
using iayos.sequentialguid;

namespace iayos.flashcardapi.Domain.Concrete.Card.GetCardById
{
	public class GetCardByIdGateway : FlashCardGateway, IFindCardByIdFromMsSqlDb, IFindDeckByIdFromMsSqlDb
	{
		public GetCardByIdGateway(IDbConnection dbConnection, ISequentialGuidGenerator guidGenerator) : base(dbConnection, guidGenerator)
		{
		}

		public CardModel GetCardModelById(Guid cardId)
		{
			var cardModel = this.FindCardById(cardId);
			if (cardModel == null) throw new Exception("NotFound");
			return cardModel;
		}

	}
}