﻿using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck;
using iayos.flashcardapi.Domain.Interactor.Deck.GetDeckById;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Deck;

namespace iayos.flashcardapi.Api.Endpoints
{
	public class DeckEndpoints : FlashCardApiPresenter
	{

		public CreateDeckRequestResponse Post(CreateDeckRequest request)
		{
			var agent = new UserModel();

			var createDeckInteractor = TryResolve<CreateDeckInteractor>();
			var createDeckInput = (CreateDeckInput)request;
			var createDeckOutput = createDeckInteractor.Handle(agent, createDeckInput);

			var getDeckInteractor = TryResolve<GetDeckByIdInteractor>();
			var getDeckInput = new GetDeckByIdInput { DeckId = createDeckOutput.DeckId };
			var getDeckOutput = getDeckInteractor.Handle(agent, getDeckInput);

			var response = new CreateDeckRequestResponse { Result = getDeckOutput.Deck };
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