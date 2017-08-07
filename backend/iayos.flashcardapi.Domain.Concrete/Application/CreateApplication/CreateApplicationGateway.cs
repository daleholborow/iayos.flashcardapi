using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Application.CreateApplication
{
	public class CreateApplicationGateway : FlashCardGateway, ICreateApplicationGateway, IFindApplicationByNameFromMsSqlDb
	{
		public CreateApplicationGateway(IDbConnection dbConnection) : base(dbConnection)
		{
		}


		public Guid Insert(ApplicationModel application)
		{
			var table = application.ToApplicationTable();
			Db.Insert(table);
			return table.ApplicationId;
		}


		public ApplicationModel FindApplicationByName(string applicationName)
		{
			var application = this.FindApplicationByNameFromDb(applicationName);
			return application;
		}
	}
}