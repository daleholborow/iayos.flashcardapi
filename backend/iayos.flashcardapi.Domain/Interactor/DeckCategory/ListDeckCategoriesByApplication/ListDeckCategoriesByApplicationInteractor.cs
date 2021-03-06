﻿using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.DeckCategory.ListDeckCategoriesByApplication
{
	public class ListDeckCategoriesByApplicationInteractor : IInteractor<ListDeckCategoriesByApplicationInput, ListDeckCategoriesByApplicationOutput>
	{
		private readonly IListDeckCategoriesByApplicationGateway _gateway;

		public ListDeckCategoriesByApplicationInteractor(IListDeckCategoriesByApplicationGateway gateway)
		{
			_gateway = gateway;
		}


		public ListDeckCategoriesByApplicationOutput Handle(UserModel agent, ListDeckCategoriesByApplicationInput input)
		{
			var deckCategories = _gateway.ListDeckCategoriesByApplicationId(input.ApplicationId, input.IncludeDecks);

			return new ListDeckCategoriesByApplicationOutput
			{
				DeckCategories = deckCategories
			};
		}


		private void ThrowOnInsufficientPermissions(UserModel agent)
		{
			// nothing for now
		}

	}
}