using iayos.flashcardapi.Api.Infrastructure;
using ServiceStack.Configuration;

namespace iayos.flashcardapi.Api.Test.Infrastructure
{
	public class UnitTestApiSettings : IFlashCardApiSettings
	{
		public bool ServiceStackDebugMode => true;

		public bool ServiceStackWriteErrorsToResponse => false;

		public string ServiceStackHandlerFactoryPath => "api";

		public string ConnectionString => ConfigUtils.GetConnectionString("flashcardapi.ConnString");
	}
}