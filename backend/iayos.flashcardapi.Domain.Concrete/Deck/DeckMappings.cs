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
			return model;
		}

		public static DeckTable ToDeckTable(this DeckModel model)
		{
			var row = model.ConvertTo<DeckTable>();
			return row;
		}
	}
}
