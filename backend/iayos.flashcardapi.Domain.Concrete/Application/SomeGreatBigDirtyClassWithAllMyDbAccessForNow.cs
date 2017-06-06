//using System;
//using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
//using iayos.flashcardapi.Domain.Interactor.Application.Find;
//using iayos.flashcardapi.DomainModel.Models;
//using ServiceStack.OrmLite;

//namespace iayos.flashcardapi.Domain.Concrete.Application
//{
//	public static class SomeGreatBigDirtyClassWithAllMyDbAccessForNow
//	{
//		public static ApplicationModel FindApplicationTableByName<TDomainLogic>(this TDomainLogic logic, string applicationName) 
//			where TDomainLogic : IFindApplicationByName, IHasDbConnection
//		{
//			var table = logic.Db.Select<ApplicationTable>(x => x.Name == applicationName); //SELECT by typed expression
//			// todo map to ApplicationModel and return!!
//			throw new NotImplementedException("Some goodies here!");
//		}
//	}
//}