using System.Collections.Generic;

namespace iayos.flashcardapi.DomainModel.Models
{
	/// <summary>
	/// Which Application is this deck being created for?
	/// E.g. SimpleSuomi, EspanolMadeEasy etc
	/// </summary>
	public class ApplicationModel : Infrastructure.DomainModel
	{
		public int ApplicationId { get; set; }

		public string Name { get; set; }
		
		public ICollection<DeckModel> Decks { get; set; } = new List<DeckModel>();

	}
}