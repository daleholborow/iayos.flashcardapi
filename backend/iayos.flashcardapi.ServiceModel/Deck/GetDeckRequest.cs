using System;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Deck
{
	[Route("/decks/{deckId}", HttpMethods.Get)]
	public class GetDeckRequest : IReturn<GetDeckRequestResponse>
	{
		public Guid DeckId { get; set; }
	}
}