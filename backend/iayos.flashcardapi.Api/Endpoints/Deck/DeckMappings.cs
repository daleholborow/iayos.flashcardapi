using iayos.flashcardapi.Api.Endpoints.Card;
using iayos.flashcardapi.Domain.Dto.Deck;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Api.Endpoints.Deck
{
	public static class DeckMappings
	{

		public static DeckDto ToDeckDto(this DeckModel model)
		{
			var dto = model.ConvertTo<DeckDto>();
			dto.Cards = model.Cards.ConvertAll(x => x.ToCardDto());
			return dto;
		}


		
	}
}
