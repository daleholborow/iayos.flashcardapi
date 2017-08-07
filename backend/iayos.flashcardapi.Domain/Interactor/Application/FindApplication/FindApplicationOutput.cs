using iayos.flashcardapi.Domain.Dto.Application;

namespace iayos.flashcardapi.Domain.Interactor.Application.Find
{
	public class FindApplicationOutput
	{
		/// <summary>
		/// Matching application if one found that met criteria
		/// </summary>
		public ApplicationDto Application { get; set; }
	}
}