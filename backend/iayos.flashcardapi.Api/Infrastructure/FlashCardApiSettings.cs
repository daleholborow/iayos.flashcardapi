using ServiceStack.Configuration;

namespace iayos.flashcardapi.Api.Infrastructure
{
	public class FlashCardApiSettings : IFlashCardApiSettings
	{
		public bool ServiceStackDebugMode => true;

		public bool ServiceStackWriteErrorsToResponse => true;

		public string ServiceStackHandlerFactoryPath => "api";

		public string ConnectionString => ConfigUtils.GetConnectionString("flashcardapi.ConnString");

	}
}