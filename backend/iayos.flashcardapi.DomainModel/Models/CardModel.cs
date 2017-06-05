namespace iayos.flashcardapi.DomainModel.Models {

	public class CardModel : Infrastructure.DomainModel
	{
		
		/// <summary>
		/// The order that card appears in the Deck
		/// </summary>
		public int Order { get; set; }


		public DeckModel Deck { get; set; }


		public string FrontText { get; set; }


		public string BackText { get; set; }
	}

}