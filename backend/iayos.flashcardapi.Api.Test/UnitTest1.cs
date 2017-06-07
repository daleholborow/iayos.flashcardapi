using System;
using Funq;
using iayos.flashcardapi.Api.Service;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.DomainModel.Flags;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Application.Messages;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Xunit;

namespace iayos.flashcardapi.Api.Test
{

	public class AppHost : AppSelfHostBase
	{
		public AppHost() : base("REST Example", typeof(ApplicationService).Assembly) { }

		public override void Configure(Container container)
		{
			container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider));

			using (var db = container.Resolve<IDbConnectionFactory>().Open())
			{
				db.CreateTableIfNotExists<UserTable>();
				db.CreateTableIfNotExists<ApplicationTable>();
				db.CreateTableIfNotExists<DeckTable>();
				db.CreateTableIfNotExists<CardTable>();
				
			}
		}
	}


	public class UnitTest1
	{
		const string BaseUri = "http://localhost:2000/";
		ServiceStackHost appHost;

		public UnitTest1()
		{
			//Start your AppHost on TestFixture SetUp
			appHost = new AppHost()
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
				var card = new CardModel { Order = i+1, FrontText = "Front"+1, BackText = "Back"+i };
				repo.Save(card);
				ModelLinker.LinkOneToOne(topVerbsDeck, d => d.Cards, card, c => c.Deck);
			}

			var kitchenDeck = new DeckModel { Name = "Kitchen Items", FrontLanguage = LanguageFlag.ENGLISH, BackLanguage = LanguageFlag.FINNISH };
			repo.Save(kitchenDeck);
			ModelLinker.LinkOneToOne(applicationModel, am => am.Decks, kitchenDeck, d => d.Application);


		}
	}
}
