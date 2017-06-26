using System;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Deck
{
	public static class DeckMixins
	{
		public static DeckModel FindDeckByNameFromDb(
			this IFindDeckByNameFromMsSqlDb implementation, string name)
		{
			var row = implementation.Db.Single<DeckTable>(x => x.Name == name);
			var model = row.ToDeckModel();
			return model;
		}


		public static DeckModel FindDeckById(
			this IFindDeckByIdFromMsSqlDb implementation, Guid id)
		{
			var row = implementation.Db.Single<DeckTable>(x => x.DeckId == id);
			var model = row.ToDeckModel();
			return model;
		}
	}
}
