using System;
using ServiceStack;
using ServiceStack.Auth;

namespace iayos.flashcardapi.Api.Test
{
	public class CustomAuthProvider : AuthProvider
	{
		public CustomAuthProvider()
		{
			this.Provider = "custom";
		}

		public override bool IsAuthorized(IAuthSession session, IAuthTokens tokens, Authenticate request = null)
		{
			return false;
		}

		public override object Authenticate(IServiceBase authService, IAuthSession session, Authenticate request)
		{
			throw new NotImplementedException();
		}
	}
}