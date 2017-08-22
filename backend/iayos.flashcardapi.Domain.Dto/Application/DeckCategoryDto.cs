using System;
using System.Collections.Generic;
using iayos.flashcardapi.Domain.Dto.Deck;

namespace iayos.flashcardapi.Domain.Dto.Application
{
	public class DeckCategoryDto
	{
		public Guid DeckCategoryId { get; set; }

		public string Name { get; set; }

		public List<DeckDto> Decks { get; set; } = new List<DeckDto>();
	}
}