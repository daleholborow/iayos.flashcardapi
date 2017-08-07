using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Application
{
	[Route("/application/{applicationId}/deckCategories")]
	public class ListDeckCategoriesByApplicationRequest : IReturn<ListDeckCategoriesByApplicationRequestResponse>
	{
		/// <summary>
		/// Should the deck categories also contain their nested decks details
		/// </summary>
		public bool IncludeDecks { get; set; }
	}
}