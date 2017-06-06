//using System.Data;
//using System.Linq;
//using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
//using ServiceStack.OrmLite;

//namespace iayos.flashcardapi.Domain.Concrete.Application
//{
//	public static class ReusableLogic
//	{
//		public static ApplicationTable FindApplicationTableByName(this IDbConnection db, string applicationName)
//		{
//			var records = db.Select<ApplicationTable>(x => x.Name == applicationName); 
//			return records.Single();
//		}
//	}
//}