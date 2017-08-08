using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck;
using iayos.flashcardapi.Domain.Interactor.Deck.GetDeckById;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Deck;
using ServiceStack;

namespace iayos.flashcardapi.Api.Endpoints
{
	public class DeckService : FlashCardApiService
	{

		public CreateDeckRequestResponse Post(CreateDeckRequest request)
		{
			var agent = new UserModel();

			var createDeckInteractor = TryResolve<CreateDeckInteractor>();
			var createDeckInput = request.ConvertTo<CreateDeckInput>();
			var createDeckOutput = createDeckInteractor.Handle(agent, createDeckInput);

			var response = new CreateDeckRequestResponse { Result = createDeckOutput.DeckId };
			return response;
		}


		public GetDeckRequestResponse Get(GetDeckRequest request)
		{
			var agent = new UserModel();

			var getDeckInteractor = TryResolve<GetDeckByIdInteractor>();
			var getDeckInput = new GetDeckByIdInput { DeckId = request.DeckId };
			var getDeckOutput = getDeckInteractor.Handle(agent, getDeckInput);

			var response = new GetDeckRequestResponse { Result = getDeckOutput.Deck };
			return response;
		}

	}

}