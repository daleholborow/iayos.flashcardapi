using System.Reflection;
using Funq;
using ServiceStack;
using ServiceStack.Api.Swagger;

namespace iayos.flashcardapi.Api.Infrastructure
{
	public class FlashcardAspAppHost : AppHostBase, IConfigurableFlashcardApiAppHost
	{
		public IFlashCardApiSettings _settings { get; }

		public FlashcardAspAppHost(string serviceName, params Assembly[] assembliesWithServices)
			: base(serviceName, assembliesWithServices)
		{
			_settings = new FlashCardApiSettings();
		}


		public override void Configure(Container container)
		{
			this.ConfigureApiAppHostContainer(container);

			Plugins.Add(new SwaggerFeature());
		}

	}
}
