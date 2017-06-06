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


	//
//	public interface IFindApplicationByNameMsSql : IFindApplicationByName
//	{
//		
//	}
//
//	
//	public class FindApplicationDomainLogicMsSql : 
//		DomainLogicMsSql, 
//		IFindApplicationByNameMsSql
//	{
//		//public ApplicationModel FindApplicationTableByName(string name)
//		//{
//		//	var model = SomeGreatBigDirtyClassWithAllMyDbAccessForNow.FindApplicationTableByName(this, name);
//		//	return model;
//		//}
//		public ApplicationModel FindApplicationTableByName(string applicationName)
//		{
//			throw new NotImplementedException();
//		}
//	}
//
//
//	public class CreateApplicationValidator :
//		DomainLogicMsSql, 
//		ICreateApplicationValidator,
//		IFindApplicationByNameMsSql
//	{
//		public void ThrowOnInsufficientPermissions(UserModel agent)
//		{
//			throw new System.NotImplementedException();
//		}
//
//		public void ThrowOnNonUniqueApplicationName(string requestName)
//		{
//			var applicationTable = this.Db.FindApplicationTableByName(requestName);
//
//		}
//
//		public void ThrowOnInvalidApplicationName(string requestName)
//		{
//			throw new NotImplementedException();
//		}
//
//		//public ApplicationModel FindApplicationTableByName(string applicationName)
//		//{
//		//	//return ShitStorm.FindApplicationTableByName(this, applicationName);
//		//	return FindApplicationTableByName(applicationName);
//		//}
//	}
//
//	public static class ShitStorm
//	{
//		public static ApplicationModel FindApplicationTableByName(this IFindApplicationByNameMsSql mssqlLogic, string applicationName)
//		{
//			throw new NotImplementedException();
//		}
//
//		public static ApplicationModel FindApplicationTableByName<TDomainLogic>(this TDomainLogic logic, string applicationName)
//			where TDomainLogic : IFindApplicationByName, IHasDbConnection
//		{
//			var table = logic.Db.Select<ApplicationTable>(x => x.Name == applicationName); //SELECT by typed expression
//			// todo map to ApplicationModel and return!!
//			throw new NotImplementedException("Some goodies here!");
//		}
//	}
//
//	//public class CreateApplicationMsSqlValidator : DomainLogicMsSql, ICreateApplicationValidator
//	//{
//	//	public ApplicationModel FindApplicationTableByName(string name)
//	//	{
//	//		var model = SomeGreatBigDirtyClassWithAllMyDbAccessForNow.FindApplicationTableByName(this, name);
//	//		return model;
//	//	}
//
//	//	public void ThrowOnInsufficientPermissions(UserModel agent)
//	//	{
//	//		throw new System.NotImplementedException();
//	//	}
//
//	//	public void ThrowOnNonUniqueApplicationName(string requestName)
//	//	{
//	//		throw new System.NotImplementedException();
//	//	}
//	//}
}