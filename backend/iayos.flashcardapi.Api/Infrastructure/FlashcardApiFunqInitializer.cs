//using Funq;
//using iayos.flashcardapi.Domain.Concrete.Application.CreateApplication;
//using iayos.flashcardapi.Domain.Concrete.Application.GetApplication;
//using iayos.flashcardapi.Domain.Concrete.Deck.CreateDeck;
//using iayos.flashcardapi.Domain.Concrete.Deck.GetDeckById;
//using iayos.flashcardapi.Domain.Interactor.Application;
//using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
//using iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck;
//using iayos.flashcardapi.Domain.Interactor.Deck.GetDeckById;
//using iayos.sequentialguid;

//namespace iayos.flashcardapi.Api.Infrastructure
//{
	
//	public static class FlashcardApiFunqInitializer
//	{
//		public static void InitializeOurContainerForGlory(Container container)
//		{
//			container.Register<ISequentialGuidGenerator>(c => new MySqlDbSequentialGuidGenerator());

//			container.RegisterAutoWired<GetApplicationByIdInteractor>();
//			container.RegisterAutoWiredAs<GetApplicationByIdGateway, IGetApplicationByIdGateway>();
//			//container.RegisterAutoWiredAs<GetApplicationValidator, IGetApplicationValidator>();

//			container.RegisterAutoWired<CreateApplicationInteractor>();
//			container.RegisterAutoWiredAs<CreateApplicationGateway, ICreateApplicationGateway>();

//			container.RegisterAutoWired<GetDeckByIdInteractor>();
//			container.RegisterAutoWiredAs<GetDeckByIdGateway, IGetDeckByIdGateway>();
//			//container.RegisterAutoWiredAs<GetDeckValidator, IGetDeckValidator>();

//			container.RegisterAutoWired<CreateDeckInteractor>();
//			container.RegisterAutoWiredAs<CreateDeckGateway, ICreateDeckGateway>();
//			//container.RegisterAutoWiredAs<CreateDeckValidator, ICreateCardValidator>();

//			/*
//			container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider));
//			container.Register<IDbConnection>(c => c.Resolve<IDbConnectionFactory>().Open());
//			container.Register<ISequentialGuidGenerator>(c => new MsSqlDbSequentialGuidGenerator());
//			*/
//		}
//	}
//}