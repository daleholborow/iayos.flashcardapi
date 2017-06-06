using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Deck.Create;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Deck.Messages;

namespace iayos.flashcardapi.Api.Service
{

	public class DeckService : FlashCardApiService
	{

		public object Post(CreateDeckRequest request)
		{
			var interactor = TryResolve<CreateDeckInteractor>();
			var agent = new UserModel();
			var result = interactor.Handle(agent, request);
			return result;
		}


		/*/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public ListQuestionnairesMessageResponse Get(ListQuestionnairesMessage request)
		{
			var interactor = TryResolve<ListQuestionnairesInteractor>();
			ListQuestionnairesMessageResponse messageResponse = interactor.Handle(request);
			return messageResponse;
		}*/

	}

}