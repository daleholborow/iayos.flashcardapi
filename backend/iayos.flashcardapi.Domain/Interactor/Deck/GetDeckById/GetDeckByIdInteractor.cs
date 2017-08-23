using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Deck.GetDeckById
{
	public class GetDeckByIdInteractor : IInteractor<GetDeckByIdInput, GetDeckByIdOutput>
	{

		private readonly IGetDeckByIdGateway _gateway;

		public GetDeckByIdInteractor(IGetDeckByIdGateway gateway)
		{
			_gateway = gateway;
		}

		public GetDeckByIdOutput Handle(UserModel agent, GetDeckByIdInput input)
		{
			// Can this agent perform this action?
			ThrowOnInsufficientPermissions(agent);

			// pass domainmodel to gateway for persistence
			var model = _gateway.GetDeckById(input.DeckId);

			// return the bare minimum of data!
			var output = new GetDeckByIdOutput
			{
				Deck = model
			};
			return output;
		}


		private void ThrowOnInsufficientPermissions(UserModel agent)
		{
			// nothing for now
		}
	}
}