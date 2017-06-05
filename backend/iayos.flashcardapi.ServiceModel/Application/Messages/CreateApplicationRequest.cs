using iayos.flashcardapi.Domain.Interactor.Application;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Application.Messages
{
	[Route("/applications", HttpMethods.Post)]
	public class CreateApplicationRequest : CreateApplicationInput, IReturn<CreateApplicationRequestResponse>
	{
	}
}