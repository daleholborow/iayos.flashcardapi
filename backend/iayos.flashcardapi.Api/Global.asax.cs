using System;
using iayos.flashcardapi.Api.Endpoints.Application;
using iayos.flashcardapi.Api.Infrastructure;

namespace iayos.flashcardapi.Api
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			new FlashCardApiAppHostBase("FlashCardApi (TM) API, by eladaus", typeof(ApplicationService).Assembly).Init();
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}