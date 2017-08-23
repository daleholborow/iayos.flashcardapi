using System.Linq;
using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.DeckCategory.ListDeckCategoriesByApplication;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.DeckCategory;
using ServiceStack;

namespace iayos.flashcardapi.Api.Endpoints.DeckCategory
{
	public class DeckCategoryService : FlashCardApiService
	{
		public ListDeckCategoriesByApplicationRequestResponse Get(ListDeckCategoriesByApplicationRequest request)
		{
			var agent = new UserModel();

			var deckCategoriesByApplicationInteractor = TryResolve<ListDeckCategoriesByApplicationInteractor>();
			var deckCategoriesByApplicationInput = request.ConvertTo<ListDeckCategoriesByApplicationInput>();
			var deckCategoriesByApplicationOutput =
				deckCategoriesByApplicationInteractor.Handle(agent, deckCategoriesByApplicationInput);

			var deckCategories = deckCategoriesByApplicationOutput.DeckCategories.OrderBy(dc => dc.Name).ToList();
			deckCategories.ForEach(dc => dc.Decks = dc.Decks.OrderBy(d => d.Name).ToList());

			var response =
				new ListDeckCategoriesByApplicationRequestResponse
				{
					Results = deckCategories
					.ConvertAll(x => x.ToDeckCategoryDto())
					.ToList()
				};
			return response;
		}
	}
}