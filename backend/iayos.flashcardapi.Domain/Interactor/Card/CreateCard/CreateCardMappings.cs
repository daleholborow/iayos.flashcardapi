using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Interactor.Card.CreateCard
{
	public static class CreateCardMappings
	{
		public static CardModel ToCardModel(this CreateCardInput input)
		{
			var model = input.ConvertTo<CardModel>();
			return model;
		}
	}
}