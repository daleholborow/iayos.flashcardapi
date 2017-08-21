using System.Reflection;
using Funq;
using iayos.core.db;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Text;

namespace iayos.flashcardapi.Api.Infrastructure
{

	public class FlashCardApiAppHostBase : AppHostBase
	{
		protected FlashCardApiSettings _settings;

		public FlashCardApiAppHostBase(string serviceName, params Assembly[] assembliesWithServices)
			: base(serviceName, assembliesWithServices)
		{
			_settings = new FlashCardApiSettings();
		}


		public override void Configure(Container container)
		{
			//AddAuthentication(container); //Uncomment to enable User Authentication

			SetConfig(new HostConfig
			{
				DebugMode = _settings.ServiceStackDebugMode,
				DefaultContentType = MimeTypes.Json,
				HandlerFactoryPath = _settings.ServiceStackHandlerFactoryPath,
				WriteErrorsToResponse = _settings.ServiceStackWriteErrorsToResponse
			});

			// Important - forces ServiceStack to return standardized dates that can have their timezone offset information correctly parsed and processed by moment in JS.
			JsConfig.DateHandler = DateHandler.ISO8601;

			// Set JSON web services to return idiomatic JSON camelCase properties   
			JsConfig.EmitCamelCaseNames = true;

			Plugins.Add(new SwaggerFeature());

			FlashcardApiFunqInitializer.InitializeOurContainerForGlory(container);

			//container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider));
			

			OrmLiteInitialiser.ConfigureOrmLite(container, _settings.ConnectionString);
			container.Register(c => c.Resolve<IDbConnectionFactory>().Open());
		}
	}
}
