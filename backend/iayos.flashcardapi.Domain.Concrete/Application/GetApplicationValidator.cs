using System;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Application
{
	public class GetApplicationValidator : IGetApplicationValidator
	{
		public void ThrowOnInsufficientPermissions(UserModel agent)
		{
			//throw new NotImplementedException();
			// TODO check perms
		}
	}
}