using Funq;
using iayos.core.db;
using iayos.flashcardapi.Domain.Concrete.Application.CreateApplication;
using iayos.flashcardapi.Domain.Concrete.Application.GetApplication;
using iayos.flashcardapi.Domain.Concrete.Deck.CreateDeck;
using iayos.flashcardapi.Domain.Concrete.Deck.GetDeckById;
using iayos.flashcardapi.Domain.Concrete.DeckCategory;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
using iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck;
using iayos.flashcardapi.Domain.Interactor.Deck.GetDeckById;
using iayos.flashcardapi.Domain.Interactor.DeckCategory.ListDeckCategoriesByApplication;
using iayos.sequentialguid;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Text;

namespace iayos.flashcardapi.Api.Infrastructure
{
	public static class ConfigurableFlashcardApiAppHostExtensions
	{
		public static void ConfigureApiAppHostContainer(this IConfigurableFlashcardApiAppHost host, Container container)
		{
			var ssHost = host as ServiceStackHost;
			ssHost.SetConfig(new HostConfig
			{
				DebugMode = host._settings.ServiceStackDebugMode,
				DefaultContentType = MimeTypes.Json,
				HandlerFactoryPath = host._settings.ServiceStackHandlerFactoryPath,
				WriteErrorsToResponse = host._settings.ServiceStackWriteErrorsToResponse
			});

			// Important - forces ServiceStack to return standardized dates that can have their timezone offset information correctly parsed and processed by moment in JS.
			JsConfig.DateHandler = DateHandler.ISO8601;

			// Set JSON web services to return idiomatic JSON camelCase properties   
			JsConfig.EmitCamelCaseNames = true;

			OrmLiteInitialiser.ConfigureOrmLite(container, host._settings.ConnectionString);
			container.Register(c => c.Resolve<IDbConnectionFactory>().Open());

			ConfigureDependencyInjection(host, container);
		}


		public static void ConfigureDependencyInjection(this IConfigurableFlashcardApiAppHost host, Container container)
		{
			container.Register<ISequentialGuidGenerator>(c => new MySqlDbSequentialGuidGenerator());

			container.RegisterAutoWired<GetApplicationByIdInteractor>();
			container.RegisterAutoWiredAs<GetApplicationByIdGateway, IGetApplicationByIdGateway>();
			//container.RegisterAutoWiredAs<GetApplicationValidator, IGetApplicationValidator>();

			container.RegisterAutoWired<CreateApplicationInteractor>();
			container.RegisterAutoWiredAs<CreateApplicationGateway, ICreateApplicationGateway>();

			container.RegisterAutoWired<ListDeckCategoriesByApplicationInteractor>();
			container.RegisterAutoWiredAs<ListDeckCategoriesByApplicationGateway, IListDeckCategoriesByApplicationGateway>();

			container.RegisterAutoWired<GetDeckByIdInteractor>();
			container.RegisterAutoWiredAs<GetDeckByIdGateway, IGetDeckByIdGateway>();
			//container.RegisterAutoWiredAs<GetDeckValidator, IGetDeckValidator>();

			container.RegisterAutoWired<CreateDeckInteractor>();
			container.RegisterAutoWiredAs<CreateDeckGateway, ICreateDeckGateway>();
		}
	}
}