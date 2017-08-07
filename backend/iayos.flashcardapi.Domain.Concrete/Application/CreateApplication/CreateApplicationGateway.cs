using System;
using System.Collections.Generic;
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


		public List<ApplicationModel> FindApplicationsByName(string applicationName)
		{
			return this.FindApplicationsByNameFromDb(applicationName);
		}
	}
}