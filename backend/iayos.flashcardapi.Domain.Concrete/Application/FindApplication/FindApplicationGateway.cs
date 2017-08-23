using System;
using System.Collections.Generic;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application.FindApplication;
using iayos.flashcardapi.DomainModel.Models;
using iayos.sequentialguid;

namespace iayos.flashcardapi.Domain.Concrete.Application.FindApplication
{
	public class FindApplicationGateway : FlashCardGateway, IFindApplicationGateway, IFindApplicationByNameFromMsSqlDb,
		IFindApplicationByIdFromMsSqlDb
	{
		public FindApplicationGateway(IDbConnection dbConnection, ISequentialGuidGenerator guidGenerator) : base(dbConnection, guidGenerator)
		{
		}

		public List<ApplicationModel> FindApplicationsByName(string applicationName)
		{
			return this.FindApplicationsByNameFromDb(applicationName);
		}


		public ApplicationModel FindApplicationById(Guid applicationId)
		{
			var application = ApplicationMixins.FindApplicationByIdFromDb(this, applicationId);
			return application;
		}
	}
}
