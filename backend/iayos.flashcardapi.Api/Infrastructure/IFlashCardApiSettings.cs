namespace iayos.flashcardapi.Api.Infrastructure
{
	public interface IFlashCardApiSettings
	{
		/// <summary>
		/// Enable StackTraces in development
		/// </summary>
		bool ServiceStackDebugMode { get; }

		bool ServiceStackWriteErrorsToResponse { get; }

		string ServiceStackHandlerFactoryPath { get; }

		string ConnectionString { get; }
	}
}