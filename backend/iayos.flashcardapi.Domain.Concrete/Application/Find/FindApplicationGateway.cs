using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application.Find;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Application.Find
{
	public class FindApplicationGateway : FlashCardGateway, IFindApplicationGateway, IFindApplicationModelByNameFromMsSqlDb, IFindApplicationModelByGlobalIdFromMsSqlDb
	{

		public ApplicationModel FindApplicationByName(string applicationName)
		{
			var application = this.FindApplicationModelByNameFromDb(applicationName);
			return application;
		}


		public ApplicationModel FindApplicationByGlobalId(Guid applicationGlobalId)
		{
			var application = this.FindApplicationModelByGlobalId(applicationGlobalId);
			return application;
		}

		public FindApplicationGateway(IDbConnection dbConnection) : base(dbConnection)
		{
		}
	}
}