namespace iayos.flashcardapi.Api.Infrastructure
{
	public interface IFlashCardApiSettings
	{
		bool ServiceStackDebugMode { get; }

		bool ServiceStackWriteErrorsToResponse { get; }

		string ServiceStackHandlerFactoryPath { get; }

		string ConnectionString { get; }
	}
}