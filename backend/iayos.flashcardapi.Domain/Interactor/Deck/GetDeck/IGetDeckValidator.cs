using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Deck.GetDeck
{
	public interface IGetDeckValidator
	{
		void ThrowOnInsufficientPermissions(UserModel agent);
	}
}