using iayos.flashcardapi.Domain.Interactor.Application.Get;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Application.Messages
{
	[Route("/applications/{applicationId}", HttpMethods.Get)]
	public class GetApplicationRequest : GetApplicationInput, IReturn<GetApplicationRequestResponse>
	{
		
	}
}