using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Application.Messages
{
	[Route("/applications/{applicationId}", HttpMethods.Get)]
	public class GetApplicationRequest : GetApplicationInput, IReturn<GetApplicationRequestResponse>
	{
		
	}
}