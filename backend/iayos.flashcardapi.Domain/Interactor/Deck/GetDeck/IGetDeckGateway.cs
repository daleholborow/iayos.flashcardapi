using System;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Deck.GetDeck
{
	public interface IGetDeckGateway
	{
		DeckModel GetDeckModelById(Guid applicationId);
	}
}