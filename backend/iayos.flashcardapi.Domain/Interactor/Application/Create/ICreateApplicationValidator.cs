using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application
{
	public interface ICreateApplicationValidator // : IFindApplicationByName
	{
		void ThrowOnInsufficientPermissions(UserModel agent);

		void ThrowOnNonUniqueApplicationName(string requestName);

		void ThrowOnInvalidApplicationName(string requestName);
	}
}