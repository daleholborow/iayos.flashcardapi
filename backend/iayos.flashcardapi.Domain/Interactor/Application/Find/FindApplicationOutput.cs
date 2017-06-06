using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.Find
{
	public class FindApplicationOutput
	{
		/// <summary>
		/// Matching application if one found that met criteria
		/// </summary>
		public ApplicationModel Application { get; set; }
	}
}