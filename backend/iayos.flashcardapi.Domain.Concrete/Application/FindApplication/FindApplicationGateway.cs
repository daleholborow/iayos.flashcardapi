using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application.Find;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Application.FindApplication
{
	public class FindApplicationGateway : FlashCardGateway, IFindApplicationGateway, IFindApplicationByNameFromMsSqlDb,
		IFindApplicationByIdFromMsSqlDb
	{
		public FindApplicationGateway(IDbConnection dbConnection) : base(dbConnection)
		{
		}

		public ApplicationModel FindApplicationByName(string applicationName)
		{
			var application = this.FindApplicationByNameFromDb(applicationName);
			return application;
		}


		public ApplicationModel FindApplicationById(Guid applicationId)
		{
			var application = ApplicationMixins.FindApplicationById(this, applicationId);
			return application;
		}
	}
}
