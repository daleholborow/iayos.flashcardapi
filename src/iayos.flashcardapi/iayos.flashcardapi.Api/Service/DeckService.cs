using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Deck;
using iayos.flashcardapi.ServiceModel.Deck.Message;

namespace iayos.flashcardapi.Api.Service
{

	public class DeckService : FlashCardApiService
	{

		public object Get(CreateDeckMessage request)
		{
			var interactor = TryResolve<CreateDeckInteractor>();
			CreateDeckMessageResponse result = interactor.Handle(request);
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