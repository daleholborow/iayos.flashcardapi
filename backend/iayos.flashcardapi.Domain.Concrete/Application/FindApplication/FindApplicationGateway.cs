using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application.Find;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Application.Find
{
	public class FindApplicationGateway : FlashCardGateway, IFindApplicationGateway, IFindApplicationModelByNameFromMsSqlDb, IFindApplicationModelByIdFromMsSqlDb
	{

		public ApplicationModel FindApplicationByName(string applicationName)
		{
			var application = this.FindApplicationModelByNameFromDb(applicationName);
			return application;
		}


		public ApplicationModel FindApplicationById(Guid applicationId)
		{
			var application = this.FindApplicationModelById(applicationId);
			return application;
		}

		public FindApplicationGateway(IDbConnection dbConnection) : base(dbConnection)
		{
		}
	}
}