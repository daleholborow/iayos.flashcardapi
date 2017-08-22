//using System.Collections.Generic;
//using Funq;
//using iayos.flashcardapi.Api.Endpoints.Application;
//using iayos.flashcardapi.Api.Infrastructure;
//using iayos.sequentialguid;
//using ServiceStack;
//using ServiceStack.Api.Swagger;
//using ServiceStack.Auth;
//using ServiceStack.Caching;

//namespace iayos.flashcardapi.Api.Test
//{
//	public class TestingAppHost : AppSelfHostBase
//	{
//		private InMemoryAuthRepository _userRep;

//		public TestingAppHost() : base("REST Example", typeof(ApplicationService).Assembly)
//		{
//		}


//		public override void Configure(Container container)
//		{
//			//Plugins.Add(new AuthFeature(() => new AuthUserSession(),
//			//	new IAuthProvider[] {
//			//		new BasicAuthProvider(), //Sign-in with HTTP Basic Auth
//			//		new CredentialsAuthProvider(), //HTML Form post of UserName/Password credentials,
//			//		//new GoogleAuthProvider()
//			//	}));
//			Plugins.Add(
//				new AuthFeature(
//					() => new CustomUserSession(),
//					GetAuthProviders(),
//					"~/")
//				{
//					RegisterPlugins = {new WebSudoFeature()}
//				}
//			);

//			Plugins.Add(new RegistrationFeature());


//			FlashcardApiFunqInitializer.InitializeOurContainerForGlory(container);
//			TestAppHostFunqContainerInitializer.InitializeOurContainerForGlory(container);

//			container.Register(new MemoryCacheClient());
//			_userRep = new InMemoryAuthRepository();
//			container.Register<IAuthRepository>(_userRep);
//		}

//		public virtual IAuthProvider[] GetAuthProviders()
//		{
//			return new IAuthProvider[]
//			{
//				//Www-Authenticate should contain basic auth, therefore register this provider first
//				new BasicAuthProvider(), //Sign-in with Basic Auth
//				new CredentialsAuthProvider(), //HTML Form post of UserName/Password credentials
//				new CustomAuthProvider()
//			};
//		}

//		public void CreateUser(int id, string username, string email, string password, List<string> roles = null,
//			List<string> permissions = null)
//		{
//			string hash;
//			string salt;
//			new SaltedHash().GetHashAndSaltString(password, out hash, out salt);

//			_userRep.CreateUserAuth(new UserAuth
//			{
//				Id = id,
//				DisplayName = "DisplayName",
//				Email = email ?? "as@if{0}.com".Fmt(id),
//				UserName = username,
//				FirstName = "FirstName",
//				LastName = "LastName",
//				PasswordHash = hash,
//				Salt = salt,
//				Roles = roles,
//				Permissions = permissions
//			},
//				password
//			);
//		}

//		public ISequentialGuidGenerator GetDbSequentialGuidGenerator()
//		{
//			return Container.Resolve<ISequentialGuidGenerator>();
//		}

//	}

//}
