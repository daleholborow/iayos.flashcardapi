using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
using iayos.flashcardapi.ServiceModel.Application.Messages;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Application
{
	[Route("/applications/{applicationId}", HttpMethods.Get)]
	public class GetApplicationByIdRequest : GetApplicationByIdInput, IReturn<GetApplicationByIdRequestResponse>
	{
		
	}
}