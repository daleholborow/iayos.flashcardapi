using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.GetApplication
{
	public class GetApplicationByIdInteractor : IInteractor<GetApplicationByIdInput, GetApplicationByIdOutput>
	{

		private readonly IGetApplicationByIdGateway _gateway;
		//private readonly IGetApplicationValidator _validator;

		public GetApplicationByIdInteractor(IGetApplicationByIdGateway gateway/*, IGetApplicationValidator validator*/)
		{
			_gateway = gateway;
			//_validator = validator;
		}

		public GetApplicationByIdOutput Handle(UserModel agent, GetApplicationByIdInput input)
		{
			// Can this agent perform this action?
			//_validator.ThrowOnInsufficientPermissions(agent);

			// pass domainmodel to gateway for persistence
			var model = _gateway.GetApplicationById(input.ApplicationId);

			// return the bare minimum of data!
			var output = new GetApplicationByIdOutput
			{
				Application = model.ToApplicationDto()
			};
			return output;
		}
	}
}