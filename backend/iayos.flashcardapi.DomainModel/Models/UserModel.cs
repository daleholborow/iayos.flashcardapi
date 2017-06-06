using System.Collections.Generic;

namespace iayos.flashcardapi.DomainModel.Models
{
	public class UserModel : Infrastructure.DomainModel
	{

		/// <summary>
		///     Collection of the decks that the User has created
		/// </summary>
		public List<DeckModel> AuthoredDecks { get; set; } = new List<DeckModel>();


		/// <summary>
		///     A collection of the decks that the User has been studying
		/// </summary>
		public List<StudyPlanModel> StudyResults { get; set; } = new List<StudyPlanModel>();
	}

	
}