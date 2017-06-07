using System;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.Find
{
	public interface IFindApplicationByGlobalId
	{
		ApplicationModel FindApplicationByGlobalId(Guid applicationGlobalId);
	}
}