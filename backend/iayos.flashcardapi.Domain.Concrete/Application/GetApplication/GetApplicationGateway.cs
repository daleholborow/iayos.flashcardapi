using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Application.GetApplication
{
	public class GetApplicationGateway : FlashCardGateway, IGetApplicationGateway, IFindApplicationByIdFromMsSqlDb
	{
		public GetApplicationGateway(IDbConnection dbConnection) : base(dbConnection)
		{
		}

		public ApplicationModel GetApplicationModelById(Guid applicationId)
		{
			var application = this.FindApplicationById(applicationId);
			if (application == null) throw new Exception("NotFound");
			return application;
		}
	}
}