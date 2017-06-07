using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application.Get;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack.Data;

namespace iayos.flashcardapi.Domain.Concrete.Application
{
	public class GetApplicationGateway : IGetApplicationGateway, IFindApplicationModelByGlobalIdFromMsSqlDb
	{

		public GetApplicationGateway(IDbConnection dbConnection)
		{
			Db = dbConnection;
		}

		public ApplicationModel GetApplicationModelByGlobalId(Guid applicationGlobalId)
		{
			var application = this.FindApplicationModelByGlobalId(applicationGlobalId);
			return application;
		}

		public IDbConnection Db { get; }
	}
}