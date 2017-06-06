using System;

namespace iayos.flashcardapi.Domain.Interactor.Application.Get
{
	public class GetApplicationInput
	{
		//public long ApplicationId { get; set; }

		public Guid? ApplicationGlobalId { get; set; }
	}
}