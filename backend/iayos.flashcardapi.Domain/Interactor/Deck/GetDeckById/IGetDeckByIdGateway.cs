﻿using System;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Deck.GetDeckById
{
	public interface IGetDeckByIdGateway
	{
		DeckModel GetDeckById(Guid deckId);
	}
}