using iayos.flashcardapi.Domain.Infrastructure;

namespace iayos.flashcardapi.Domain.Interactor.Application.Create
{
	public class CreateApplicationInteractor : IInteractor<CreateApplicationInput, CreateApplicationOutput>
	{
		private ICreateApplicationGateway _gateway;
		private ICreateApplicationValidator _validator;

		public CreateApplicationInteractor(ICreateApplicationGateway gateway, ICreateApplicationValidator validator)
		{
			_gateway = gateway;
			_validator = validator;


			//_gateway = new InMemoryDeckModelRepository();
			//_gateway = new InMemoryModelRepository<DeckModel>();
		}

		public CreateApplicationOutput Handle(CreateApplicationInput request)
		{
			
			// get values from request, validator

			// get gateway

			// map request to domainmodel

			// pass domainmodel to gateway for persistence

			// return the bare minimum of data!

			return new CreateApplicationOutput
			{
				ApplicationId = -666
			};
		}
	}
}
