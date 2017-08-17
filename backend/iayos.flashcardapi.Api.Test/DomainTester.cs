using System;
using Funq;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
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
			Assert.True(createApplicationOutput.ApplicationId != Guid.Empty);
		}


		[Fact]
		public void GetApplicationByApplicationId()
		{
			//var client = new JsonServiceClient(BaseUri);
			//var all = client.Get(new GetApplicationByIdRequest { ApplicationId = Guid.NewGuid() });
			//Assert.True(all.Result.Id == Guid.NewGuid());

			var interactor = _container.Resolve<GetApplicationByIdInteractor>();
			var getApplicationInput = new GetApplicationByIdInput {ApplicationId = Guid.NewGuid()};
			UserModel agent = new UserModel();
			var output = interactor.Handle(agent, getApplicationInput);
		}
	}
}