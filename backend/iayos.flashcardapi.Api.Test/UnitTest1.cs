using System;
using System.Data;
using Funq;
using iayos.flashcardapi.Api.Service;
using iayos.flashcardapi.Domain.Concrete.Application;
using iayos.flashcardapi.Domain.Concrete.Application.Create;
using iayos.flashcardapi.Domain.Concrete.Application.Get;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.DomainModel.Flags;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Application.Messages;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Xunit;

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

			using (var db = container.Resolve<IDbConnectionFactory>().Open())
			{
				db.CreateTableIfNotExists<UserTable>();
				db.CreateTableIfNotExists<ApplicationTable>();
				db.CreateTableIfNotExists<DeckTable>();
				db.CreateTableIfNotExists<CardTable>();
			}
		}
	}

	public class DomainTester
	{
		readonly Container _container = new Container();

		public DomainTester()
		{
			ContainerInitializer.InitializeOurContainerForGlory(_container);
		}


		[Fact]
		public void CreateApplication()
		{
			var interactor = _container.Resolve<CreateApplicationInteractor>();
			var createApplicationInput = new CreateApplicationInput { Name = "test" };
			UserModel agent = new UserModel();
			var createApplicationOutput = interactor.Handle(agent, createApplicationInput);
			Assert.True(createApplicationOutput.ApplicationGlobalId != Guid.Empty);
		}


		[Fact]
		public void GetApplicationByApplicationGlobalId()
		{
			//var client = new JsonServiceClient(BaseUri);
			//var all = client.Get(new GetApplicationRequest { ApplicationGlobalId = Guid.NewGuid() });
			//Assert.True(all.Result.GlobalId == Guid.NewGuid());

			var interactor = _container.Resolve<GetApplicationInteractor>();
			var getApplicationInput = new GetApplicationInput {ApplicationGlobalId = Guid.NewGuid()};
			UserModel agent = new UserModel();
			var output = interactor.Handle(agent, getApplicationInput);
		}
	}


	public class AppHostTester : AppSelfHostBase
	{
		public AppHostTester() : base("REST Example", typeof(ApplicationService).Assembly) { }

		public override void Configure(Container container)
		{
			ContainerInitializer.InitializeOurContainerForGlory(container);
		}
	}

	public class UnitTest1 : IDisposable
	{
		const string BaseUri = "http://localhost:2000/";
		ServiceStackHost _appHost;

		public UnitTest1()
		{
			//Start your AppHostTester on TestFixture SetUp
			_appHost = new AppHostTester()
				.Init()
				.Start(BaseUri);
		}

		[Fact]
		public void GetApplicationByApplicationGlobalId()
		{
			var client = new JsonServiceClient(BaseUri);
			var all = client.Get(new GetApplicationRequest { ApplicationGlobalId = Guid.NewGuid() });
			Assert.True(all.Result.GlobalId == Guid.NewGuid());
		}


		[Fact]
		public void TestMethod1()
		{

			var repo = new IayosRepository();

			var applicationModel = new ApplicationModel
			{
				Name = "SimpleSuomi"
			};
			repo.Save(applicationModel);

			var topVerbsDeck = new DeckModel { Name = "Top Verbs", FrontLanguage = LanguageFlag.ENGLISH, BackLanguage = LanguageFlag.FINNISH };
			repo.Save(topVerbsDeck);
			ModelLinker.LinkOneToOne(applicationModel, am => am.Decks, topVerbsDeck, d => d.Application);

			for (var i = 0; i < 20; i++)
			{
				var card = new CardModel { Order = i + 1, FrontText = "Front" + 1, BackText = "Back" + i };
				repo.Save(card);
				ModelLinker.LinkOneToOne(topVerbsDeck, d => d.Cards, card, c => c.Deck);
			}

			var kitchenDeck = new DeckModel { Name = "Kitchen Items", FrontLanguage = LanguageFlag.ENGLISH, BackLanguage = LanguageFlag.FINNISH };
			repo.Save(kitchenDeck);
			ModelLinker.LinkOneToOne(applicationModel, am => am.Decks, kitchenDeck, d => d.Application);


		}

		public void Dispose()
		{
			_appHost?.Dispose();
		}
	}
}
