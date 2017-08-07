using System;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck
{
	public interface ICreateDeckGateway
	{
		Guid Insert(DeckModel deck);

		ApplicationModel GetApplicationById(Guid applicationId);
	}
}