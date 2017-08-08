using System;

namespace iayos.flashcardapi.Domain.Interactor.Card.CreateCard
{
	public class CreateCardInput
	{
		public int Order { get; set; }


		public Guid DeckId { get; set; }


		public string FrontText { get; set; }


		public string BackText { get; set; }
	}
}