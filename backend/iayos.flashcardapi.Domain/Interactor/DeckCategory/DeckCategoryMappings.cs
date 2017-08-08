using iayos.flashcardapi.Domain.Dto.Application;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Deck;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Interactor.DeckCategory
{
	public static class DeckCategoryMappings
	{
		public static DeckCategoryDto ToDeckCategoryDto(this DeckCategoryModel model)
		{
			var dto = model.ConvertTo<DeckCategoryDto>();
			dto.Decks = model.Decks.ConvertAll(x => x.ToDeckDto());
			return dto;
		}
	}


	

	
}