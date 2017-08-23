namespace iayos.flashcardapi.Api.Infrastructure
{
	public interface IConfigurableFlashcardApiAppHost
	{
		IFlashCardApiSettings _settings { get; }
	}
}