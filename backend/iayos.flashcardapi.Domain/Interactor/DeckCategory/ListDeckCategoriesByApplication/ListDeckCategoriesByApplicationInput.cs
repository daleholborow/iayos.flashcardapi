using System;

namespace iayos.flashcardapi.Domain.Interactor.DeckCategory.ListDeckCategoriesByApplication
{
	public class ListDeckCategoriesByApplicationInput
	{
		public Guid ApplicationId { get; set; }

		public bool IncludeDecks { get; set; }
	}
}