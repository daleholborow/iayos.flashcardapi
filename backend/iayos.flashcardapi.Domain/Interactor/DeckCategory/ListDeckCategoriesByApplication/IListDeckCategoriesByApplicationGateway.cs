using System;
using System.Collections.Generic;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.DeckCategory.ListDeckCategoriesByApplication
{
	public interface IListDeckCategoriesByApplicationGateway
	{
		List<DeckCategoryModel> ListDeckCategoriesByApplicationId(Guid applicationId, bool includeDecks);
	}
}