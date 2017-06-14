using System;
using Funq;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.DomainModel.Models;
using Xunit;

namespace iayos.flashcardapi.Api.Test
{
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
}