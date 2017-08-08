using iayos.flashcardapi.Api.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Application;
using ServiceStack;

namespace iayos.flashcardapi.Api.Endpoints
{
	public class ApplicationService : FlashCardApiService
	{
		
		public CreateApplicationRequestResponse Post(CreateApplicationRequest request)
		{
			var agent = new UserModel();

			var createApplicationInteractor = TryResolve<CreateApplicationInteractor>();
			var createApplicationInput = request.ConvertTo<CreateApplicationInput>();
			var createApplicationOutput = createApplicationInteractor.Handle(agent, createApplicationInput);

			var response = new CreateApplicationRequestResponse {Result = createApplicationOutput.ApplicationId };
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