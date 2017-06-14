using System;
using System.Collections.Generic;
using System.Net;
using iayos.flashcardapi.ServiceModel.Application.Messages;
using ServiceStack;
using ServiceStack.Text;
using Xunit;

namespace iayos.flashcardapi.Api.Test
{

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

	public class UnitTest1 : IDisposable
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
		//ServiceStackHost _appHost;
		AppHostTester _appHost;

		public UnitTest1()
		{
			//Start your AppHostTester on TestFixture SetUp
			_appHost = new AppHostTester();
			_appHost.Init();
			_appHost.Start(ListeningOn);
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
			_appHost.CreateUser(1, UserName, null, Password, new List<string> { "TheRole" }, new List<string> { "ThePermission" });
			_appHost.CreateUser(2, UserNameWithSessionRedirect, null, PasswordForSessionRedirect);
			_appHost.CreateUser(3, null, EmailBasedUsername, PasswordForEmailBasedAccount);
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
		public void GetApplicationByApplicationGlobalId()
		{
			var client = new JsonServiceClient(ListeningOn);
			var all = client.Get(new GetApplicationRequest { ApplicationGlobalId = Guid.NewGuid() });
			Assert.True(all.Result.GlobalId == Guid.NewGuid());
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
			_appHost?.Dispose();
		}
	}
}
