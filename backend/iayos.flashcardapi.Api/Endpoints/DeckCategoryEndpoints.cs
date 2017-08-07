using System;
using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Deck.Messages;

namespace iayos.flashcardapi.Api.Endpoints
{
	public class DeckCategoryEndpoints : FlashCardApiPresenter
	{

		public ListDeckCategoriesByApplicationRequestResponse Get(ListDeckCategoriesByApplicationRequest request)
		{
			throw new NotImplementedException();
		}

		//public CreateDeckRequestResponse Post(CreateDeckRequest request)
		//{
		//	var agent = new UserModel();

		//	var createDeckInteractor = TryResolve<CreateDeckInteractor>();
		//	var createDeckInput = (CreateDeckInput)request;
		//	var createDeckOutput = createDeckInteractor.Handle(agent, createDeckInput);

		//	var getDeckInteractor = TryResolve<GetDeckByIdInteractor>();
		//	var getDeckInput = new GetDeckInputById { DeckId = createDeckOutput.DeckId };
		//	var getDeckOutput = getDeckInteractor.Handle(agent, getDeckInput);

		//	var response = new CreateDeckRequestResponse { Result = getDeckOutput.Deck };
		//	return response;
		//}


		//public GetDeckRequestResponse Get(GetDeckRequest request)
		//{
		//	var agent = new UserModel();

		//	var getDeckInteractor = TryResolve<GetDeckByIdInteractor>();
		//	var getDeckInput = new GetDeckInputById { DeckId = request.DeckId };
		//	var getDeckOutput = getDeckInteractor.Handle(agent, getDeckInput);

		//	var response = new GetDeckRequestResponse { Result = getDeckOutput.Deck };
		//	return response;
		//}

	}

}