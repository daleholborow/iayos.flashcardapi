using ServiceStack;
using ServiceStack.Auth;

namespace iayos.flashcardapi.Api.Test
{
	public class CustomUserSession : WebSudoAuthUserSession
	{
		public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, System.Collections.Generic.Dictionary<string, string> authInfo)
		{
			//if (session.UserAuthName == AuthTests.UserNameWithSessionRedirect)
			//	session.ReferrerUrl = AuthTests.SessionRedirectUrl;
		}

		public int Counter { get; set; }
	}
}