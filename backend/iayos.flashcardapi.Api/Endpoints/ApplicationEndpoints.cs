using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Application;
using iayos.flashcardapi.ServiceModel.Application.Messages;

namespace iayos.flashcardapi.Api.Endpoints
{
	public class ApplicationEndpoints : FlashCardApiPresenter
	{
		
		public CreateApplicationRequestResponse Post(CreateApplicationRequest request)
		{
			var agent = new UserModel();

			var createApplicationInteractor = TryResolve<CreateApplicationInteractor>();
			var createApplicationInput = (CreateApplicationInput) request;
			var createApplicationOutput = createApplicationInteractor.Handle(agent, createApplicationInput);

			var getApplicationInteractor = TryResolve<GetApplicationByIdInteractor>();
			var getApplicationByIdInput = new GetApplicationByIdInput {ApplicationId = createApplicationOutput.ApplicationId};
			var getApplicationByIdOutput = getApplicationInteractor.Handle(agent, getApplicationByIdInput);

			var response = new CreateApplicationRequestResponse {Result = getApplicationByIdOutput.Application};
			return response;
		}


		public GetApplicationByIdRequestResponse Get(GetApplicationByIdRequest request)
		{
			var agent = new UserModel();

			var getApplicationInteractor = TryResolve<GetApplicationByIdInteractor>();
			var getApplicationByIdInput = new GetApplicationByIdInput {ApplicationId = request.ApplicationId};
			var getApplicationByIdOutput = getApplicationInteractor.Handle(agent, getApplicationByIdInput);

			var response = new GetApplicationByIdRequestResponse {Result = getApplicationByIdOutput.Application};
			return response;
		}
	}
}