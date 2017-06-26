using System;

namespace iayos.flashcardapi.Domain.Interactor.Application.Find
{
	public class FindApplicationInput
	{
		/// <summary>
		/// Try to fiind a matching application by name
		/// </summary>
		public string Name { get; set; }


		public Guid? Id { get; set; }

	}
}