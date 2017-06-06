using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Dto.Application;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.Find;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.Domain.Interactor.Deck.Create;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Application.Messages;
using iayos.flashcardapi.ServiceModel.Deck.Messages;

namespace iayos.flashcardapi.Api.Service
{

	public class ApplicationService : FlashCardApiService
	{
		public CreateApplicationRequestResponse Post(CreateApplicationRequest request)
		{
			var agent = new UserModel();

			var createApplicationInteractor = TryResolve<CreateApplicationInteractor>();
			var createApplicationInput = (CreateApplicationInput) request;
			var createApplicationOutput = createApplicationInteractor.Handle(agent, createApplicationInput);

			var getApplicationInteractor = TryResolve<GetApplicationInteractor>();
			var getApplicationInput = new GetApplicationInput {ApplicationGlobalId = createApplicationOutput.ApplicationGlobalId};
			var getApplicationOutput = getApplicationInteractor.Handle(agent, getApplicationInput);
			

			var response = new CreateApplicationRequestResponse();


			response.Result = getApplicationOutput.Application;
			return response;
		}
	}

	public class DeckService : FlashCardApiService
	{

		//public CreateDeckRequestResponse Post(CreateDeckRequest request)
		//{
		//	var interactor = TryResolve<CreateDeckInteractor>();
		//	var agent = new UserModel();
		//	var result = interactor.Handle(agent, request);
		//	return result;
		//}


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