using System;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Application
{
	[Route("/applications/{applicationId}", HttpMethods.Get)]
	public class GetApplicationByIdRequest : IReturn<GetApplicationByIdRequestResponse>
	{
		public Guid ApplicationId { get; set; }
	}
}