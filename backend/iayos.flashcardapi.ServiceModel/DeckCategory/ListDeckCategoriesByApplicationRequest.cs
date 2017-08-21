using System;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.DeckCategory
{
	[Route("/applications/{applicationId}/deckCategories", HttpMethods.Get)]
	public class ListDeckCategoriesByApplicationRequest : IReturn<ListDeckCategoriesByApplicationRequestResponse>
	{

		public Guid ApplicationId { get; set; }

		/// <summary>
		/// Should the deck categories also contain their nested decks details
		/// </summary>
		public bool IncludeDecks { get; set; }
	}
}