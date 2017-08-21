using System.Data;
using Funq;
using iayos.flashcardapi.Domain.Concrete.Application.CreateApplication;
using iayos.flashcardapi.Domain.Concrete.Application.GetApplication;
using iayos.flashcardapi.Domain.Concrete.Deck.CreateDeck;
using iayos.flashcardapi.Domain.Concrete.Deck.GetDeckById;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
using iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck;
using iayos.flashcardapi.Domain.Interactor.Deck.GetDeckById;
using iayos.sequentialguid;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Api.Test
{
	public static class ContainerInitializer
	{
		public static void InitializeOurContainerForGlory(Container container)
		{
			container.Register<ISequentialGuidGenerator>(c => new MySqlDbSequentialGuidGenerator());

			container.RegisterAutoWired<GetApplicationByIdInteractor>();
			container.RegisterAutoWiredAs<GetApplicationByIdGateway, IGetApplicationByIdGateway>();
			//container.RegisterAutoWiredAs<GetApplicationValidator, IGetApplicationValidator>();

			container.RegisterAutoWired<CreateApplicationInteractor>();
			container.RegisterAutoWiredAs<CreateApplicationGateway, ICreateApplicationGateway>();

			container.RegisterAutoWired<GetDeckByIdInteractor>();
			container.RegisterAutoWiredAs<GetDeckByIdGateway, IGetDeckByIdGateway>();
			//container.RegisterAutoWiredAs<GetDeckValidator, IGetDeckValidator>();

			container.RegisterAutoWired<CreateDeckInteractor>();
			container.RegisterAutoWiredAs<CreateDeckGateway, ICreateDeckGateway>();
			//container.RegisterAutoWiredAs<CreateDeckValidator, ICreateCardValidator>();

			container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider));
			container.Register<IDbConnection>(c => c.Resolve<IDbConnectionFactory>().Open());
			container.Register<ISequentialGuidGenerator>(c => new MsSqlDbSequentialGuidGenerator());
/*

			using (var db = container.Resolve<IDbConnectionFactory>().Open())
			{
				db.CreateTableIfNotExists<UserTable>();
				db.CreateTableIfNotExists<ApplicationTable>();
				db.CreateTableIfNotExists<DeckTable>();
				db.CreateTableIfNotExists<CardTable>();
				db.CreateTableIfNotExists<ScoreTable>();
			}
*/


			

			container.Register<ICacheClient>(new MemoryCacheClient());
			var userRep = new InMemoryAuthRepository();
			container.Register<IUserAuthRepository>(userRep);

			//The IUserAuthRepository is used to store the user credentials etc.
			//Implement this interface to adjust it to your app's data storage
		}
	}

	


	
}