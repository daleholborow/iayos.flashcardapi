using System;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Concrete.Card
{
	internal static class CardMappings
	{
		public static CardModel ToCardModel(this CardTable row)
		{
			if (row == null) return null;
			var model = row.ConvertTo<CardModel>();
			return model;
		}

		public static CardTable ToCardTable(this CardModel model, Guid? deckId = null)
		{
			var row = model.ConvertTo<CardTable>();
			row.DeckId = model.Deck?.DeckId?? deckId.GetValueOrDefault();
			return row;
		}
	}
}
