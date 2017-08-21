using System.Collections.Generic;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.DeckCategory.ListDeckCategoriesByApplication
{
	public class ListDeckCategoriesByApplicationOutput
	{
		public List<DeckCategoryModel> DeckCategories { get; set; } = new List<DeckCategoryModel>();
	}
}