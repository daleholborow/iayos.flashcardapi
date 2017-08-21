using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.Domain.Interactor.DeckCategory.ListDeckCategoriesByApplication;
using iayos.flashcardapi.DomainModel.Models;
using iayos.sequentialguid;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.DeckCategory
{
	public class ListDeckCategoriesByApplicationGateway : FlashCardGateway, IListDeckCategoriesByApplicationGateway
	{

		public ListDeckCategoriesByApplicationGateway(IDbConnection dbConnection, ISequentialGuidGenerator guidGenerator) : base(dbConnection, guidGenerator)
		{
		}


		public List<DeckCategoryModel> ListDeckCategoriesByApplicationId(Guid applicationId, bool includeDecks)
		{
			var deckCategoryTables = Db.Select<DeckCategoryTable>(dc => dc.ApplicationId == applicationId);
			var decks = Db.Select<DeckTable>(dt => Sql.In(dt.DeckCategoryId, deckCategoryTables.Select(dc => dc.DeckCategoryId)));
			deckCategoryTables.Merge(decks);
			var deckCategoryModels = deckCategoryTables.ConvertAll(x => x.ToDeckCategoryModel());
			return deckCategoryModels;
		}

	}
}
