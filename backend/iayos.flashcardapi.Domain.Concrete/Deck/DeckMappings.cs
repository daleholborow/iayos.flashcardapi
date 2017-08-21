using System;
using iayos.flashcardapi.Domain.Concrete.Card;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Concrete.Deck
{
	internal static class DeckMappings
	{
		public static DeckModel ToDeckModel(this DeckTable row)
		{
			if (row == null) return null;
			var model = row.ConvertTo<DeckModel>();
			var cards = row.Cards.ConvertAll(x => x.ToCardModel());
			model.AddCards(cards);
			return model;
		}

		public static DeckTable ToDeckTable(this DeckModel model, Guid? applicationId = null, Guid? deckCategoryId = null)
		{
			var row = model.ConvertTo<DeckTable>();
			row.ApplicationId = model.Application?.ApplicationId ?? applicationId.GetValueOrDefault();
			row.DeckCategoryId = model.DeckCategory?.DeckCategoryId ?? deckCategoryId.GetValueOrDefault();
			return row;
		}
	}
}
