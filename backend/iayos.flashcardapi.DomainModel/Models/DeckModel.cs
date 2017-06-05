using System.Collections.Generic;
using iayos.flashcardapi.DomainModel.Flags;

namespace iayos.flashcardapi.DomainModel.Models
{
	public class DeckModel : Infrastructure.DomainModel
	{

		public string Name { get; set; }

		/// <summary>
		/// Which application was this deck made for
		/// </summary>
		public ApplicationModel Application { get; set; }


		///// <summary>
		///// Has the deck been shared for public use (i.e. it can no longer be edited)
		///// </summary>
		//public bool IsShared { get; set; }


		//public FrequencyModeFlag FrequencyMode { get; set; }


		/// <summary>
		/// What language are the faces of the cards recorded in?
		/// </summary>
		public LanguageFlag FrontLanguage { get; set; } = LanguageFlag.ENGLISH;


		/// <summary>
		/// What language are the backs of the cards recorded in?
		/// </summary>
		public LanguageFlag BackLanguage { get; set; } = LanguageFlag.ENGLISH;


		//		/// <summary>
		//		/// Account who created the Deck
		//		/// </summary>
		//		public UserModel Author { get; set; }


		public ICollection<CardModel> Cards { get; set; } = new List<CardModel>();
	}

}
