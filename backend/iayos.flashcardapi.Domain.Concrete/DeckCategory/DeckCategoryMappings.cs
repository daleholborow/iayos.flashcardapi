using iayos.flashcardapi.Domain.Concrete.Deck;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Concrete.DeckCategory
{
	internal static class DeckCategoryMappings
	{
		public static DeckCategoryModel ToDeckCategoryModel(this DeckCategoryTable row)
		{
			if (row == null) return null;
			var model = row.ConvertTo<DeckCategoryModel>();
			var decks = row.Decks.ConvertAll(x => x.ToDeckModel());
			model.AddDecks(decks);
			return model;
		}
	}
}