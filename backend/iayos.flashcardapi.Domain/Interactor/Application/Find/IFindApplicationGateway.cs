namespace iayos.flashcardapi.Domain.Interactor.Application.Find
{
	public interface IFindApplicationGateway : 
		IFindApplicationByName,
		IFindApplicationByGlobalId
	{
	}
}