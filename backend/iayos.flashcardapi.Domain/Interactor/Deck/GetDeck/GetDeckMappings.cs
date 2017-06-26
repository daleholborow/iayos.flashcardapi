using iayos.flashcardapi.Domain.Dto.Deck;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Interactor.Deck.GetDeck
{
	public static class GetDeckMappings
	{

		public static DeckDto ToDeckDto(this DeckModel model)
		{
			var dto = model.ConvertTo<DeckDto>();
			return dto;
		}

	}
}
