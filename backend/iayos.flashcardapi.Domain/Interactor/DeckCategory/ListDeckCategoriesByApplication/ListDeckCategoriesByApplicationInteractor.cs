using System.Collections.Generic;
using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Application;
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


		//public ListDeckCategoriesByApplicationOutput 

		public ListDeckCategoriesByApplicationOutput Handle(UserModel agent, ListDeckCategoriesByApplicationInput input)
		{
			//// Can this agent perform this action?
			//ThrowOnInsufficientPermissions(agent);

			//// validate that application doesnt exist by name already
			//ThrowOnInvalidApplicationName(input.Name);

			//// map input to domainmodel
			//var application = input.ToApplicationModel();

			//// pass domainmodel to gateway for persistence
			//application.ApplicationId = _gateway.Insert(application);

			//// return the bare minimum of data!
			//return new CreateApplicationOutput
			//{
			//	ApplicationId = application.ApplicationId
			//};

			List<DeckCategoryModel> deckCategories = _gateway.ListDeckCategoriesByApplicationId(input.ApplicationId);

			var deckCategoryDtos = deckCategories.ConvertAll(x => ApplicationMappings.ToDeckCategoryDto(x));

			return new ListDeckCategoriesByApplicationOutput
			{
				DeckCategoryDtos = deckCategoryDtos
			};
		}


		private void ThrowOnInsufficientPermissions(UserModel agent)
		{
			// nothing for now
		}

	}
}