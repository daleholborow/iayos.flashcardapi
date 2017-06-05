using System;

namespace iayos.flashcardapi.ServiceModel.Deck.Dto
{
	public class ApplicationDto
	{
		public int ApplicationId { get; set; }

		public string Name { get; set; }

		public Guid ApplicationGuid { get; set; }
	}
}