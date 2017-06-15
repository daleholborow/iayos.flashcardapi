using System;
using System.Data;
using System.Security.Cryptography;
using Funq;
using iayos.flashcardapi.Domain.Concrete.Application.Create;
using iayos.flashcardapi.Domain.Concrete.Application.Get;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
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
			container.RegisterAutoWired<GetApplicationInteractor>();
			container.RegisterAutoWiredAs<GetApplicationGateway, IGetApplicationGateway>();
			container.RegisterAutoWiredAs<GetApplicationValidator, IGetApplicationValidator>();

			container.RegisterAutoWired<CreateApplicationInteractor>();
			container.RegisterAutoWiredAs<CreateApplicationGateway, ICreateApplicationGateway>();
			container.RegisterAutoWiredAs<CreateApplicationValidator, ICreateApplicationValidator>();

			container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider));
			container.Register<IDbConnection>(c => c.Resolve<IDbConnectionFactory>().Open());
			container.Register<ISequentialGuidGenerator>(c => new MsSqlDbSequentialGuidGenerator());

			using (var db = container.Resolve<IDbConnectionFactory>().Open())
			{
				db.CreateTableIfNotExists<UserTable>();
				db.CreateTableIfNotExists<ApplicationTable>();
				db.CreateTableIfNotExists<DeckTable>();
				db.CreateTableIfNotExists<CardTable>();
			}


			

			container.Register<ICacheClient>(new MemoryCacheClient());
			var userRep = new InMemoryAuthRepository();
			container.Register<IUserAuthRepository>(userRep);

			//The IUserAuthRepository is used to store the user credentials etc.
			//Implement this interface to adjust it to your app's data storage
		}
	}

	


	
}