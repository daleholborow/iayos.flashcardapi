using System;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Deck
{
	[Route("applications/{applicationId}/decks/{deckId}", HttpMethods.Get)]
	public class GetDeckRequest : IReturn<GetDeckRequestResponse>
	{
		public Guid ApplicationId { get; set; }

		public Guid DeckId { get; set; }
	}
}