using Funq;
using iayos.sequentialguid;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Api.Test
{
	public static class TestAppHostFunqContainerInitializer
	{
		public static void InitializeOurContainerForGlory(Container container)
		{
			container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider));
			container.Register(c => c.Resolve<IDbConnectionFactory>().Open());
			container.Register<ISequentialGuidGenerator>(c => new MsSqlDbSequentialGuidGenerator());

			//container.Register<ICacheClient>(new MemoryCacheClient());
			//var userRep = new InMemoryAuthRepository();
			//container.Register<IUserAuthRepository>(userRep);

			//The IUserAuthRepository is used to store the user credentials etc.
			//Implement this interface to adjust it to your app's data storage
		}
	}
}
