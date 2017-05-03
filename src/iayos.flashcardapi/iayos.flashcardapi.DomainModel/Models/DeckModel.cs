using System.Collections.Generic;
using iayos.flashcardapi.DomainModel.Flags;

namespace iayos.flashcardapi.DomainModel.Models
{

	public class DeckModel : Infrastructure.DomainModel
	{

		public int DeckId { get; set; }


		/// <summary>
		/// Has the deck been shared for public use (i.e. it can no longer be edited)
		/// </summary>
		public bool IsShared { get; set; }


		public FrequencyModeFlag FrequencyMode { get; set; }


		/// <summary>
		/// What language are the faces of the cards recorded in?
		/// </summary>
		public LanguageFlag CardFaceLanguage { get; set; }


		/// <summary>
		/// What language are the backs of the cards recorded in?
		/// </summary>
		public LanguageFlag CardBackLanguage { get; set; }
		

		/// <summary>
		/// Account who created the Deck
		/// </summary>
		public UserModel Author { get; set; }


		public List<CardModel> Cards { get; set; } = new List<CardModel>();
	}

}
