using iayos.flashcardapi.Api.Endpoints.Deck;
using iayos.flashcardapi.Domain.Dto.Application;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Api.Endpoints
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