using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application
{
	public class CreateApplicationInteractor : IInteractor<CreateApplicationInput, CreateApplicationOutput>
	{
		private readonly ICreateApplicationGateway _gateway;
		private readonly ICreateApplicationValidator _validator;

		public CreateApplicationInteractor(ICreateApplicationGateway gateway, ICreateApplicationValidator validator)
		{
			_gateway = gateway;
			_validator = validator;
		}

		public CreateApplicationOutput Handle(UserModel agent, CreateApplicationInput request)
		{
			// Can this agent perform this action?
			_validator.ThrowOnInsufficientPermissions(agent);

			// validate that application doesnt exist by name already
			_validator.ThrowOnInvalidApplicationName(request.Name);

			// map request to domainmodel
			var application = request.ToApplicationModel();

			// pass domainmodel to gateway for persistence
			var applicationId = _gateway.Insert(application);

			// return the bare minimum of data!
			return new CreateApplicationOutput
			{
				ApplicationId = applicationId
			};
		}
	}
}