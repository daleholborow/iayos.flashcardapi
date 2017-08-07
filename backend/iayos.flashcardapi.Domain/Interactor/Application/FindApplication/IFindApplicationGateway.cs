using System;
using System.Collections.Generic;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.FindApplication
{
	public interface IFindApplicationGateway 
	{
		ApplicationModel FindApplicationById(Guid applicationId);

		List<ApplicationModel> FindApplicationsByName(string applicationName);
	}
}