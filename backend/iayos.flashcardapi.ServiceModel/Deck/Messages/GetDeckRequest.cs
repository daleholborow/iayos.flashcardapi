using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.Domain.Interactor.Deck.GetDeck;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Deck.Messages
{
	[Route("/deck/{deckId}", HttpMethods.Get)]
	public class GetDeckRequest : GetDeckInput, IReturn<GetDeckRequestResponse>
	{
		
	}
}