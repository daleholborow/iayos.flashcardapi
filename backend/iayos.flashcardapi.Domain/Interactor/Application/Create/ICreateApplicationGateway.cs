using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application
{
	public interface ICreateApplicationGateway
	{
		long Insert(ApplicationModel application);
	}
}