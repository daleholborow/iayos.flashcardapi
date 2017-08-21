using System.Reflection;
using Funq;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Text;

namespace iayos.flashcardapi.Api.Infrastructure {

	public class FlashCardApiAppHostBase : AppHostBase
	{

		public FlashCardApiAppHostBase(string serviceName, params Assembly[] assembliesWithServices) : base(serviceName, assembliesWithServices)
		{
		}


		public override void Configure(Container container)
		{

			//AddAuthentication(container); //Uncomment to enable User Authentication
			SetConfig(new HostConfig
			{
				DebugMode = true,
				DefaultContentType = MimeTypes.Json,
				HandlerFactoryPath = "api",
				WriteErrorsToResponse = true
			});


			//Important - forces ServiceStack to return standardized dates that can have their timezone offset information correctly parsed and processed by moment in JS.
			JsConfig.DateHandler = DateHandler.ISO8601;


			// Set JSON web services to return idiomatic JSON camelCase properties   
			JsConfig.EmitCamelCaseNames = true;

			Plugins.Add(new SwaggerFeature());

		}


		//private void AddAuthentication(Container container)
		//{
		//	container.Register<IUserAuthRepository>(c =>
		//		new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

		//	container.Resolve<IUserAuthRepository>().InitSchema();

		//	Plugins.Add(new AuthFeature(() => new AuthUserSession(),
		//		new IAuthProvider[] {
		//			new CredentialsAuthProvider(),
		//		}
		//	));
		//}
	}

}