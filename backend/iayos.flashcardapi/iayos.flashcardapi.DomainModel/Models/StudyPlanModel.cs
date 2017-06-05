using System.Collections.Generic;
using iayos.flashcardapi.DomainModel.Flags;

namespace iayos.flashcardapi.DomainModel.Models {

	public class StudyPlanModel : Infrastructure.DomainModel
	{

		public int StudyPlanId { get; set; }


		/// <summary>
		/// By default this would be inherited from the Deck, but a student might choose to override it?
		/// </summary>
		public FrequencyModeFlag FrequencyMode { get; set; }


		/// <summary>
		/// Which student user account submitted a score for this card
		/// </summary>
		public UserModel Student { get; set; }


		/// <summary>
		/// Which deck is being studied and scored
		/// </summary>
		public DeckModel Deck { get; set; }


		/// <summary>
		/// All the scores for all the cards in the deck
		/// </summary>
		public List<CardScoreModel> CardScores { get; set; } = new List<CardScoreModel>();

	}

}