using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using iayos.flashcardapi.ServiceModel.Application;
using iayos.flashcardapi.ServiceModel.Application.Messages;
using iayos.sequentialguid;
using Ploeh.AutoFixture;
using ServiceStack;
using ServiceStack.Text;
using Xunit;

namespace iayos.flashcardapi.Api.Test
{
	public abstract class TestingContext : IDisposable
	{
		public const string UserName = "user";
		public const string Password = "p@55word";
		public const string UserNameWithSessionRedirect = "user2";
		public const string PasswordForSessionRedirect = "p@55word2";
		public const string SessionRedirectUrl = "specialLandingPage.html";
		public const string LoginUrl = "specialLoginPage.html";
		public const string EmailBasedUsername = "user@email.com";
		public const string PasswordForEmailBasedAccount = "p@55word3";

		const string ListeningOn = "http://localhost:2000/";
		//ServiceStackHost _testingAppHost;
		TestingAppHost _testingAppHost;

		/// <summary>
		/// Get direct access to the testing apphost db connection
		/// </summary>
		public IDbConnection Db => _testingAppHost.GetDbConnection();

		public ISequentialGuidGenerator DbGuidGenerator => _testingAppHost.GetDbSequentialGuidGenerator();

		/// <summary>
		/// Fixture used to generate randomised test data
		/// </summary>
		protected Fixture Fixture = new Fixture();

		public TestingContext()
		{
			//Start your TestingAppHost on TestFixture SetUp
			_testingAppHost = new TestingAppHost();
			_testingAppHost.Init();
			_testingAppHost.Start(ListeningOn);
		}


		IServiceClient GetClientWithUserPassword()
		{
			return new JsonServiceClient(ListeningOn)
			{
				UserName = UserName,
				Password = Password
			};
		}


		IServiceClient GetClient()
		{
			return new JsonServiceClient(ListeningOn);
		}

		

		public void MakeSomeUsersDale()
		{
			_testingAppHost.CreateUser(1, UserName, null, Password, new List<string> { "TheRole" }, new List<string> { "ThePermission" });
			_testingAppHost.CreateUser(2, UserNameWithSessionRedirect, null, PasswordForSessionRedirect);
			_testingAppHost.CreateUser(3, null, EmailBasedUsername, PasswordForEmailBasedAccount);
		}

		
		[Fact]
		public void No_Credentials_throws_UnAuthorized()
		{
			try
			{
				var client = GetClient();
				var request = new Secured { Name = "test" };
				var response = client.Send<SecuredResponse>(request);

				//Assert.Fail("Shouldn't be allowed");
				throw new Exception("Shouldnt be allowed");
			}
			catch (WebServiceException webEx)
			{
				Assert.Equal((int)HttpStatusCode.Unauthorized, webEx.StatusCode);
				Console.WriteLine(webEx.ResponseDto.Dump());
			}
		}

		[Fact]
		public void GetApplicationByApplicationId()
		{
			var client = GetClient();
			var all = client.Get(new GetApplicationByIdRequest { ApplicationId = Guid.NewGuid() });
			Assert.True(all.Result.Id == Guid.NewGuid());
		}


		/// <summary>
		/// Models the front page of SS where we load up all the active decks in the application
		/// </summary>
		[Fact]
		public void GetDecksByApplicationId()
		{

			// Inject a new Application

			// Inject some Decks


			//var client = GetClient();
			//var all = client.Get(new GetApplicationByIdRequest { ApplicationId = Guid.NewGuid() });
			//Assert.True(all.Result.Id == Guid.NewGuid());
		}

/*

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
*/

		public void Dispose()
		{
			_testingAppHost?.Dispose();
		}
	}


	[Route("/secured")]
	public class Secured : IReturn<SecuredResponse>
	{
		public string Name { get; set; }
	}

	public class SecuredResponse
	{
		public string Result { get; set; }

		public ResponseStatus ResponseStatus { get; set; }
	}
}
