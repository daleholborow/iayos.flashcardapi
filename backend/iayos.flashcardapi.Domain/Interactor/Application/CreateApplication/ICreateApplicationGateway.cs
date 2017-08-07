using System;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application
{
	public interface ICreateApplicationGateway
	{
		Guid Insert(ApplicationModel application);

		ApplicationModel FindApplicationByName(string applicationName);
	}
}