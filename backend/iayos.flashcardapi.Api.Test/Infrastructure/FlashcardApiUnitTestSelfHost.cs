using System.Diagnostics;
using Funq;
using iayos.flashcardapi.Api.Endpoints.Application;
using iayos.flashcardapi.Api.Infrastructure;
using iayos.sequentialguid;
using ServiceStack;

namespace iayos.flashcardapi.Api.Test.Infrastructure
{
	public class FlashcardApiUnitTestSelfHost : AppSelfHostBase, IConfigurableFlashcardApiAppHost
	{

		[DebuggerStepThrough]
		public FlashcardApiUnitTestSelfHost() : base("iayos flashcard api Unit Test Host", typeof(ApplicationService).Assembly)
		{
			_settings = new UnitTestApiSettings();
		}


		public IFlashCardApiSettings _settings { get; }


		[DebuggerStepThrough]
		public override void Configure(Container container)
		{
			this.ConfigureApiAppHostContainer(container);
		}


		public ISequentialGuidGenerator GetDbSequentialGuidGenerator()
		{
			return Container.Resolve<ISequentialGuidGenerator>();
		}
	}
}
