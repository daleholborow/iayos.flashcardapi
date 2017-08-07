using System;
using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Application.FindApplication;
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

		public FindApplicationOutput Handle(UserModel agent, FindApplicationInput input)
		{
			throw new NotImplementedException();
		}
	}
}