using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using ServiceStack;

namespace iayos.flashcardapi.Api.Test
{
	public class ApiUnitTester : IDisposable
	{
		private readonly UnitTestSelfHost _apiAppHost;

		private bool _disposed;

		private JsonServiceClient _jsonServiceClient;

		private readonly int _port;


		public ApiUnitTester()
		{
			// create an apphost at the baseurl+port
			_port = GetRandomUnusedPort();

			_apiAppHost = new UnitTestSelfHost();
			_apiAppHost
				.Init()
				.Start(BaseUrl);
		}

		public JsonServiceClient JsonServiceClient => _jsonServiceClient ?? (_jsonServiceClient =
			                                              new JsonServiceClient(BaseUrl + _apiAppHost._settings
				                                                                    .ServiceStackHandlerFactoryPath));

		public string BaseUrl => $"http://localhost:{_port}/";

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		[DebuggerStepThrough]
		public static int GetRandomUnusedPort()
		{
			var listener = new TcpListener(IPAddress.Any, 0);
			listener.Start();
			var port = ((IPEndPoint) listener.LocalEndpoint).Port;
			listener.Stop();
			return port;
		}


		protected void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_apiAppHost?.Dispose();
				}

				// release any unmanaged objects
				// set object references to null

				_disposed = true;
			}
		}
	}
}
