using iayos.flashcardapi.Domain.Interactor.Deck;
using iayos.flashcardapi.Domain.Interactor.Deck.Create;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Deck.Messages
{
	[Route("/decks", HttpMethods.Post)]
	public class CreateDeckRequest : CreateDeckInput, IReturn<CreateDeckRequestResponse>
	{
	}
}