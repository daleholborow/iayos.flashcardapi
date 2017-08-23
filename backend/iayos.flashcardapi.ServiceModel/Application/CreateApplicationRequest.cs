using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Application
{
	[Route("/applications", HttpMethods.Post)]
	public class CreateApplicationRequest : IReturn<CreateApplicationRequestResponse>
	{
		public string Name { get; set; }
	}
}