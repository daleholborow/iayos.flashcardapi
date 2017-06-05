namespace iayos.flashcardapi.DomainModel.Models {

	public class CardModel : Infrastructure.DomainModel
	{

		public int CardId { get; set; }


		/// <summary>
		/// The order that card appears in the Deck
		/// </summary>
		public int Order { get; set; }


		public CardFaceModel Front { get; set; }


		public CardFaceModel Back { get; set; }

	}

}