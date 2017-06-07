using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Application.Get
{
	public class GetApplicationGateway : FlashCardGateway, IGetApplicationGateway, IFindApplicationModelByGlobalIdFromMsSqlDb
	{
		public GetApplicationGateway(IDbConnection dbConnection) : base(dbConnection)
		{
		}

		public ApplicationModel GetApplicationModelByGlobalId(Guid applicationGlobalId)
		{
			var application = this.FindApplicationModelByGlobalId(applicationGlobalId);
			if (application == null) throw new Exception("NotFound");
			return application;
		}
	}
}