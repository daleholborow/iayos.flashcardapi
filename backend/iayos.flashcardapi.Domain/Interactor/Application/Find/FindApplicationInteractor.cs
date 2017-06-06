using System;
using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.Find
{
	public class FindApplicationInteractor : IInteractor<FindApplicationInput, FindApplicationOutput>
	{
		private IFindApplicationGateway _gateway;
		private IFindApplicationValidator _validator;

		public FindApplicationInteractor(IFindApplicationGateway gateway, IFindApplicationValidator validator)
		{
			_gateway = gateway;
			_validator = validator;
		}

		public FindApplicationOutput Handle(UserModel agent, FindApplicationInput request)
		{
			throw new NotImplementedException();
		}
	}
}