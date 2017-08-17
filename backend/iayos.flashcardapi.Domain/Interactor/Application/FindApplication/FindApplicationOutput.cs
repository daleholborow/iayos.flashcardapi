using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.FindApplication
{
	public class FindApplicationOutput
	{
		/// <summary>
		/// Matching application if one found that met criteria
		/// </summary>
		public ApplicationModel Application { get; set; }
	}
}