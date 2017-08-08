using System;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.GetApplication
{
	public interface IGetApplicationByIdGateway
	{
		ApplicationModel GetApplicationById(Guid applicationId);
	}
}