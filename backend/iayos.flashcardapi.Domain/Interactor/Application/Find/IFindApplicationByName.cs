using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.Find
{
	public interface IFindApplicationByName
	{
		ApplicationModel FindApplicationByName(string applicationName);
	}
}