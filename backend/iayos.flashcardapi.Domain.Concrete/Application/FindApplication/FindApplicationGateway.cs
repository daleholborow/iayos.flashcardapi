using System;
using System.Collections.Generic;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application.Find;
using iayos.flashcardapi.Domain.Interactor.Application.FindApplication;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Application.FindApplication
{
	public class FindApplicationGateway : FlashCardGateway, IFindApplicationGateway, IFindApplicationByNameFromMsSqlDb,
		IFindApplicationByIdFromMsSqlDb
	{
		public FindApplicationGateway(IDbConnection dbConnection) : base(dbConnection)
		{
		}

		public List<ApplicationModel> FindApplicationsByName(string applicationName)
		{
			return this.FindApplicationsByNameFromDb(applicationName);
		}


		public ApplicationModel FindApplicationById(Guid applicationId)
		{
			var application = ApplicationMixins.FindApplicationById(this, applicationId);
			return application;
		}
	}
}
