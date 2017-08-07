using System;
using System.Collections.Generic;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application
{
	public interface ICreateApplicationGateway
	{
		Guid Insert(ApplicationModel application);

		List<ApplicationModel> FindApplicationsByName(string applicationName);
	}
}