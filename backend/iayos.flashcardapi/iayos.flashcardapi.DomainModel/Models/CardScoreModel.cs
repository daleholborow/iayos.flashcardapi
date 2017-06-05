namespace iayos.flashcardapi.DomainModel.Models {

	public class CardScoreModel : Infrastructure.DomainModel
	{

		public int CardScoreId { get; set; }
		

		/// <summary>
		/// Parent record in which this card was answered
		/// </summary>
		public StudyPlanModel StudyPlan { get; set; }

		

		/// <summary>
		/// Which card was the student answering
		/// </summary>
		public CardModel Card { get; set; }


		/// <summary>
		/// How many times has the usser answered this card correctly
		/// </summary>
		public int CorrectCount { get; set; }


		/// <summary>
		/// How many times has the user answered this card incorrectly
		/// </summary>
		public int IncorrectCount { get; set; }

	}

}