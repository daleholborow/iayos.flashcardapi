using iayos.flashcardapi.Domain.Interactor.Deck.Create;
using iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Deck.Messages
{
	[Route("/decks", HttpMethods.Post)]
	public class CreateDeckRequest : CreateDeckInput, IReturn<CreateDeckRequestResponse>
	{
	}
}