using System;
using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.Get
{
	public class GetApplicationInteractor : IInteractor<GetApplicationInput, GetApplicationOutput>
	{
		public GetApplicationOutput Handle(UserModel agent, GetApplicationInput request)
		{
			throw new NotImplementedException();
		}
	}


	
}