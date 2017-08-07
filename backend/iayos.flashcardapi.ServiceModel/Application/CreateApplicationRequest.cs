using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.ServiceModel.Application.Messages;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Application
{
	[Route("/applications", HttpMethods.Post)]
	public class CreateApplicationRequest : CreateApplicationInput, IReturn<CreateApplicationRequestResponse>
	{
	}
}