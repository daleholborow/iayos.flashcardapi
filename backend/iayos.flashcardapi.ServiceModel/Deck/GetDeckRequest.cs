using iayos.flashcardapi.Domain.Interactor.Deck.GetDeckById;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Deck
{
	[Route("/deck/{deckId}", HttpMethods.Get)]
	public class GetDeckRequest : GetDeckByIdInput, IReturn<GetDeckRequestResponse>
	{
		
	}
}