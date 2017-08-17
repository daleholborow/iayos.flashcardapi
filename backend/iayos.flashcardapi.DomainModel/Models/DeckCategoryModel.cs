using System;
using System.Collections.Generic;

namespace iayos.flashcardapi.DomainModel.Models
{
	public class DeckCategoryModel : Infrastructure.DomainModel
	{
		public Guid DeckId { get; set; }

		public string Name { get; set; }

		public List<DeckModel> Decks { get; set; } = new List<DeckModel>();

		public Guid DeckCategoryId { get; set; }
	}


	
}