using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Application
{
	public class CreateApplicationGateway :
			ICreateApplicationGateway,
			IHasDbConnection
	{

		public IDbConnection Db { get; }


		public CreateApplicationGateway(IDbConnection dbConnection)
		{
			Db = dbConnection;
		}

		public long Insert(ApplicationModel application)
		{
			var table = application.ToApplicationTable();
			var id = Db.Insert(table, true);
			return id;
		}

		
	}

}
