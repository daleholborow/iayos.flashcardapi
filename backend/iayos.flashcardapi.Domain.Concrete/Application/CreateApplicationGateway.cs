using System;
using System.Data;
using System.Linq;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.Domain.Interactor.Application.Find;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Application
{
	public class CreateApplicationGateway :
			ICreateApplicationGateway,
			IHasDbConnection
	{
		public long Insert(ApplicationModel application)
		{
			// doo some db cool stuff here with ServiceStack
			//throw new System.NotImplementedException();
			var table = application.ConvertTo<ApplicationTable>();
			var id = Db.Insert(table, true);
			return id;
		}

		public IDbConnection Db { get; set; }
	}


	public class CreateApplicationValidator : ICreateApplicationValidator, IHasDbConnection
	{
		public void ThrowOnInsufficientPermissions(UserModel agent)
		{
			throw new System.NotImplementedException();
		}

		public void ThrowOnNonUniqueApplicationName(string requestName)
		{
			throw new System.NotImplementedException();
		}

		public void ThrowOnInvalidApplicationName(string requestName)
		{
			// see if name is unique and throw if not
			var table = Db.FindApplicationByName(requestName);
			if (table != null) throw new Exception("Not Allowed Dup;licates!!!");

			throw new System.NotImplementedException();
		}
		

		public IDbConnection Db { get; set; }
	}

	public class FindApplicationGateway : IFindApplicationByName, IHasDbConnection
	{
		public ApplicationModel FindApplicationByName(string applicationName)
		{
			var table = Db.FindApplicationByName(applicationName);
			var model = table.ConvertTo<ApplicationModel>();
			return model;
		}

		public IDbConnection Db { get; set; }
	}

	public static class StoredProcedures
	{
		public static ApplicationTable FindApplicationByName(this IDbConnection db, string applicationName)
		{
			var records = db.Select<ApplicationTable>(x => x.Name == applicationName); //SELECT by typed expression
			return records.Single();
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
//		//public ApplicationModel FindApplicationByName(string name)
//		//{
//		//	var model = SomeGreatBigDirtyClassWithAllMyDbAccessForNow.FindApplicationByName(this, name);
//		//	return model;
//		//}
//		public ApplicationModel FindApplicationByName(string applicationName)
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
//			var applicationTable = this.Db.FindApplicationByName(requestName);
//
//		}
//
//		public void ThrowOnInvalidApplicationName(string requestName)
//		{
//			throw new NotImplementedException();
//		}
//
//		//public ApplicationModel FindApplicationByName(string applicationName)
//		//{
//		//	//return ShitStorm.FindApplicationByName(this, applicationName);
//		//	return FindApplicationByName(applicationName);
//		//}
//	}
//
//	public static class ShitStorm
//	{
//		public static ApplicationModel FindApplicationByName(this IFindApplicationByNameMsSql mssqlLogic, string applicationName)
//		{
//			throw new NotImplementedException();
//		}
//
//		public static ApplicationModel FindApplicationByName<TDomainLogic>(this TDomainLogic logic, string applicationName)
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
//	//	public ApplicationModel FindApplicationByName(string name)
//	//	{
//	//		var model = SomeGreatBigDirtyClassWithAllMyDbAccessForNow.FindApplicationByName(this, name);
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