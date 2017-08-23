using System;
using System.Collections.Generic;
using iayos.flashcardapi.DomainModel.Flags;

namespace iayos.flashcardapi.Domain.Dto.Deck
{
	public class DeckDto
	{

		public Guid DeckId { get; set; }


		public string Name { get; set; }


		public LanguageFlag FrontLanguage { get; set; }


		public LanguageFlag BackLanguage { get; set; }


		public List<CardDto> Cards { get; set; } = new List<CardDto>();
	}
}