using iayos.flashcardapi.Domain.Dto.Deck;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Api.Endpoints.Card
{
	public static class CardMappings
	{
		public static CardDto ToCardDto(this CardModel model)
		{
			var dto = model.ConvertTo<CardDto>();
			return dto;
		}
	}
}