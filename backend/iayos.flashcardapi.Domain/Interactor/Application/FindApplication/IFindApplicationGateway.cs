using System;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.Find
{
	public interface IFindApplicationGateway 
	{
		ApplicationModel FindApplicationByGlobalId(Guid applicationGlobalId);

		ApplicationModel FindApplicationByName(string applicationName);
	}
}