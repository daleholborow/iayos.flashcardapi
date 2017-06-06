using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

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


			//_gateway = new InMemoryDeckModelRepository();
			//_gateway = new InMemoryModelRepository<DeckModel>();
		}

		public CreateApplicationOutput Handle(UserModel agent, CreateApplicationInput request)
		{
			// get values from request, validator

			_validator.ThrowOnInsufficientPermissions(agent);

			_validator.ThrowOnNonUniqueApplicationName(request.Name);

			_validator.ThrowOnInvalidApplicationName(request.Name);

			// get gateway

			// validate that application doesnt exist by name already

			// map request to domainmodel
			var application = request.ConvertTo<ApplicationModel>();


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