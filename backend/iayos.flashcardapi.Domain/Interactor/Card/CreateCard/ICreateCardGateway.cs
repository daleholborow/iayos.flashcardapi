using System;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Card.CreateCard
{
	public interface ICreateCardGateway
	{
		Guid Insert(CardModel card);

		ApplicationModel GetApplicationById(Guid applicationId);
	}
}