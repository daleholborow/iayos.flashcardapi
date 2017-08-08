using System;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Card
{
	public static class CardMixins
	{
		public static CardModel FindCardById(this IFindCardByIdFromMsSqlDb implementation, Guid id)
		{
			var row = implementation.Db.Single<CardTable>(x => x.CardId == id);
			var model = row.ToCardModel();
			return model;
		}
	}
}
