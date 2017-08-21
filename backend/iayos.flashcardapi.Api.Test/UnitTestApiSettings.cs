using iayos.flashcardapi.Api.Infrastructure;
using ServiceStack.Configuration;

namespace iayos.flashcardapi.Api.Test
{
	public class UnitTestApiSettings : IFlashCardApiSettings
	{
		public bool ServiceStackDebugMode => false;

		public bool ServiceStackWriteErrorsToResponse => false;

		public string ServiceStackHandlerFactoryPath => "api";

		public string ConnectionString => ConfigUtils.GetConnectionString("flashcardapi.ConnString");
	}
}