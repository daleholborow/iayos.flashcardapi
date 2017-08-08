using System;
using iayos.flashcardapi.DomainModel.Flags;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Deck
{
	[Route("/decks", HttpMethods.Post)]
	public class CreateDeckRequest : IReturn<CreateDeckRequestResponse>
	{
		public Guid ApplicationId { get; set; }


		public Guid DeckCategoryId { get; set; }


		public string Name { get; set; }


		/// <summary>
		/// What language are the front of the cards recorded in?
		/// </summary>
		public LanguageFlag FrontLanguage { get; set; }


		/// <summary>
		/// What language are the backs of the cards recorded in?
		/// </summary>
		public LanguageFlag BackLanguage { get; set; }
	}
}