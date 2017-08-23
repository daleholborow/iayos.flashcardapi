using System;

namespace iayos.flashcardapi.Domain.Dto.Deck
{
	public class CardDto
	{
		public Guid CardId { get; set; }


		public int Order { get; set; }


		public string FrontText { get; set; }


		public string BackText { get; set; }
	}
}