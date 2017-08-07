using System.Collections.Generic;
using iayos.flashcardapi.Domain.Dto.Application;

namespace iayos.flashcardapi.Domain.Interactor.DeckCategory.ListDeckCategoriesByApplication
{
	public class ListDeckCategoriesByApplicationOutput
	{
		public List<DeckCategoryDto> DeckCategoryDtos { get; set; } = new List<DeckCategoryDto>();
	}
}