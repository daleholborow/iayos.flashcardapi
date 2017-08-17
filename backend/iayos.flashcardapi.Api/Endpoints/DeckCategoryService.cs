﻿using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.DeckCategory.ListDeckCategoriesByApplication;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.DeckCategory;
using ServiceStack;

namespace iayos.flashcardapi.Api.Endpoints
{
	public class DeckCategoryService : FlashCardApiService
	{

		public ListDeckCategoriesByApplicationRequestResponse Get(ListDeckCategoriesByApplicationRequest request)
		{
			var agent = new UserModel();

			var deckCategoriesByApplicationInteractor = TryResolve<ListDeckCategoriesByApplicationInteractor>();
			var deckCategoriesByApplicationInput = request.ConvertTo<ListDeckCategoriesByApplicationInput>();
			var deckCategoriesByApplicationOutput = deckCategoriesByApplicationInteractor.Handle(agent, deckCategoriesByApplicationInput);

			var response = new ListDeckCategoriesByApplicationRequestResponse { Results = deckCategoriesByApplicationOutput.DeckCategoryDtos };
			return response;
		}

	}

}