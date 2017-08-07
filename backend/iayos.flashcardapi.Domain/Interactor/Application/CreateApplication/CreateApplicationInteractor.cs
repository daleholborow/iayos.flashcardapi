using System;
using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application
{
	public class CreateApplicationInteractor : IInteractor<CreateApplicationInput, CreateApplicationOutput>
	{
		private readonly ICreateApplicationGateway _gateway;

		public CreateApplicationInteractor(ICreateApplicationGateway gateway)
		{
			_gateway = gateway;
		}


		public CreateApplicationOutput Handle(UserModel agent, CreateApplicationInput input)
		{
			// Can this agent perform this action?
			ThrowOnInsufficientPermissions(agent);

			// validate that application doesnt exist by name already
			ThrowOnInvalidApplicationName(input.Name);

			// map input to domainmodel
			var application = input.ToApplicationModel();

			// pass domainmodel to gateway for persistence
			application.ApplicationId = _gateway.Insert(application);

			// return the bare minimum of data!
			return new CreateApplicationOutput
			{
				ApplicationId = application.ApplicationId
			};
		}


		private void ThrowOnInsufficientPermissions(UserModel agent)
		{
			// nothing for now
		}


		private void ThrowOnInvalidApplicationName(string applicationName)
		{
			applicationName = applicationName.Trim();

			// see if name is unique and throw if not
			var applications = _gateway.ListApplicationsByName(applicationName);
			if (applications != null) throw new Exception("Not allowed duplicate application names");
			if (applicationName.Contains("dale")) throw new Exception("Can't have your name in here while testing mate");
		}
	}
}