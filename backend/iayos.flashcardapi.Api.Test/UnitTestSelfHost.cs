using System.Diagnostics;
using Funq;
using iayos.flashcardapi.Api.Endpoints.Application;
using iayos.flashcardapi.Api.Infrastructure;
using ServiceStack;

namespace iayos.flashcardapi.Api.Test
{
	public class UnitTestSelfHost : AppSelfHostBase, IConfigurableFlashcardApiAppHost
	{
		private readonly int _port;
		private JsonServiceClient _jsonServiceClient;


		[DebuggerStepThrough]
		public UnitTestSelfHost() : base("iayos flashcard api Unit Test Host", typeof(ApplicationService).Assembly)
		{
			_settings = new UnitTestApiSettings();
		}

		public string BaseUrl => $"http://localhost:{_port}/";


		public JsonServiceClient JsonServiceClient => _jsonServiceClient ?? (_jsonServiceClient =
			                                              new JsonServiceClient(
				                                              BaseUrl + _settings.ServiceStackHandlerFactoryPath));

		public IFlashCardApiSettings _settings { get; }


		[DebuggerStepThrough]
		public override void Configure(Container container)
		{
			this.ConfigureApiAppHostContainer(container);
		}
	}
}
