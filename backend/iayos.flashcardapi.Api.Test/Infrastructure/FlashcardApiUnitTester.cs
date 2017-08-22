using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using iayos.sequentialguid;
using ServiceStack;

namespace iayos.flashcardapi.Api.Test.Infrastructure
{
	public class FlashcardApiUnitTester : IDisposable
	{
		private readonly FlashcardApiUnitTestSelfHost _apiAppHost;

		private readonly int _port;

		private bool _disposed;

		private JsonServiceClient _jsonServiceClient;

		public FlashcardApiUnitTester()
		{
			// create an apphost at the baseurl+port
			_port = GetRandomUnusedPort();

			_apiAppHost = new FlashcardApiUnitTestSelfHost();
			_apiAppHost
				.Init()
				.Start(BaseUrl);
		}


		public IDbConnection Db => _apiAppHost.GetDbConnection();

		public ISequentialGuidGenerator DbGuidGenerator => _apiAppHost.GetDbSequentialGuidGenerator();

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
