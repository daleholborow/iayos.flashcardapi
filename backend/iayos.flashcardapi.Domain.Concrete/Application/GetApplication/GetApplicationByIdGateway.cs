using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application.GetApplication;
using iayos.flashcardapi.DomainModel.Models;
using iayos.sequentialguid;

namespace iayos.flashcardapi.Domain.Concrete.Application.GetApplication
{
	public class GetApplicationByIdGateway : FlashCardGateway, IGetApplicationByIdGateway, IGetApplicationByIdFromMsSqlDb
	{
		public GetApplicationByIdGateway(IDbConnection dbConnection, ISequentialGuidGenerator guidGenerator) : base(dbConnection, guidGenerator)
		{
		}

		public ApplicationModel GetApplicationById(Guid applicationId)
		{
			var application = this.GetApplicationByIdFromDb(applicationId);
			return application;
		}
	}
}