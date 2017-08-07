using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Deck.GetDeck
{
	public class GetDeckInteractor : IInteractor<GetDeckInput, GetDeckOutput>
	{

		private readonly IGetDeckGateway _gateway;
		private readonly IGetDeckValidator _validator;

		public GetDeckInteractor(IGetDeckGateway gateway, IGetDeckValidator validator)
		{
			_gateway = gateway;
			_validator = validator;
		}

		public GetDeckOutput Handle(UserModel agent, GetDeckInput input)
		{
			// Can this agent perform this action?
			_validator.ThrowOnInsufficientPermissions(agent);

			// pass domainmodel to gateway for persistence
			var model = _gateway.GetDeckModelById(input.DeckId);

			// return the bare minimum of data!
			var output = new GetDeckOutput
			{
				Deck = model.ToDeckDto()
			};
			return output;
		}
	}
}