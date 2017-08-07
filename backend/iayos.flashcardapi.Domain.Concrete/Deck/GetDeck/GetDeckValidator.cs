using iayos.flashcardapi.Domain.Interactor.Deck.GetDeck;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Deck.GetDeck
{
	public class GetDeckValidator : IGetDeckValidator
	{
		public void ThrowOnInsufficientPermissions(UserModel agent)
		{
			//throw new NotImplementedException();
			// TODO check perms
		}
	}
}