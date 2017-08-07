using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck
{
	public static class CreateDeckMappings
	{
		public static DeckModel ToDeckModel(this CreateDeckInput input)
		{
			var model = input.ConvertTo<DeckModel>();
			return model;
		}
	}
}