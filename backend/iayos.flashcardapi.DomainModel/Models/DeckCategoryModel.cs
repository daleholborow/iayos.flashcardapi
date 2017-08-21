using System;
using System.Collections.Generic;

namespace iayos.flashcardapi.DomainModel.Models
{

	public class DeckCategoryModel : Infrastructure.DomainModel
	{
		public Guid DeckCategoryId { get; set; }

		public string Name { get; set; }

		public List<DeckModel> Decks { get; set; } = new List<DeckModel>();


		public void AddDecks(List<DeckModel> decks)
		{
			Decks.AddRange(decks);
			decks.ForEach(d => d.DeckCategory = this);
		}
	}
	
}