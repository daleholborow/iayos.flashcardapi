//using System.Data;
//using iayos.flashcardapi.Domain.Interactor.Application;
//using iayos.flashcardapi.DomainModel.Models;
//using ServiceStack.OrmLite;

//namespace iayos.flashcardapi.Domain.Concrete.Application.Create
//{
//	public class CreateApplicationGateway : FlashCardGateway, ICreateApplicationGateway
//	{
//		public CreateApplicationGateway(IDbConnection dbConnection) : base(dbConnection)
//		{
//		}


//		public long Insert(ApplicationModel application)
//		{
//			var table = application.ToApplicationTable();
//			var id = Db.Insert(table, true);
//			return id;
//		}
//	}
//}