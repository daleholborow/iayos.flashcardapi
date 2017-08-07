using iayos.flashcardapi.Domain.Dto.Deck;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Interactor.Deck
{
	public static class DeckMappings
	{

		public static DeckDto ToDeckDto(this DeckModel model)
		{
			var dto = model.ConvertTo<DeckDto>();
			return dto;
		}

	}
}
