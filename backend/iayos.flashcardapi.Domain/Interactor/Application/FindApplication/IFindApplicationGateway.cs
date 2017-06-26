using System;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.Find
{
	public interface IFindApplicationGateway 
	{
		ApplicationModel FindApplicationById(Guid applicationId);

		ApplicationModel FindApplicationByName(string applicationName);
	}
}