using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Card.CreateCard
{
	public class CreateCardInteractor : IInteractor<CreateCardInput, CreateCardOutput>
	{
		private readonly ICreateCardGateway _gateway;


		public CreateCardInteractor(ICreateCardGateway gateway)
		{
			_gateway = gateway;
		}


		public CreateCardOutput Handle(UserModel agent, CreateCardInput input)
		{
			//_gateway.BeginTransaction();
			var cardModel = input.ToCardModel();
			var cardId = _gateway.Insert(cardModel);
			//_gateway.CommitTransaction();

			return new CreateCardOutput {CardId = cardId};
		}
	}
}