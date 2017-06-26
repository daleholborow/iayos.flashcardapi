using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Application.Messages;

namespace iayos.flashcardapi.Api.Presenters
{
	public class ApplicationPresenter : FlashCardApiPresenter
	{
		
		public CreateApplicationRequestResponse Post(CreateApplicationRequest request)
		{
			var agent = new UserModel();

			var createApplicationInteractor = TryResolve<CreateApplicationInteractor>();
			var createApplicationInput = (CreateApplicationInput) request;
			var createApplicationOutput = createApplicationInteractor.Handle(agent, createApplicationInput);

			var getApplicationInteractor = TryResolve<GetApplicationInteractor>();
			var getApplicationInput = new GetApplicationInput {ApplicationId = createApplicationOutput.ApplicationId};
			var getApplicationOutput = getApplicationInteractor.Handle(agent, getApplicationInput);

			var response = new CreateApplicationRequestResponse {Result = getApplicationOutput.Application};
			return response;
		}


		public GetApplicationRequestResponse Get(GetApplicationRequest request)
		{
			var agent = new UserModel();

			var getApplicationInteractor = TryResolve<GetApplicationInteractor>();
			var getApplicationInput = new GetApplicationInput {ApplicationId = request.ApplicationId};
			var getApplicationOutput = getApplicationInteractor.Handle(agent, getApplicationInput);

			var response = new GetApplicationRequestResponse {Result = getApplicationOutput.Application};
			return response;
		}
	}
}