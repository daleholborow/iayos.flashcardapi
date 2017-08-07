using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.Get
{
	public class GetApplicationInteractor : IInteractor<GetApplicationInput, GetApplicationOutput>
	{

		private readonly IGetApplicationGateway _gateway;
		private readonly IGetApplicationValidator _validator;

		public GetApplicationInteractor(IGetApplicationGateway gateway, IGetApplicationValidator validator)
		{
			_gateway = gateway;
			_validator = validator;
		}

		public GetApplicationOutput Handle(UserModel agent, GetApplicationInput input)
		{
			// Can this agent perform this action?
			_validator.ThrowOnInsufficientPermissions(agent);

			// pass domainmodel to gateway for persistence
			var model = _gateway.GetApplicationModelById(input.ApplicationId);

			// return the bare minimum of data!
			var output = new GetApplicationOutput
			{
				Application = model.ToApplicationDto()
			};
			return output;
		}
	}
}