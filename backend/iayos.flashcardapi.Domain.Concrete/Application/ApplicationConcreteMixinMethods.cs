using System;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Application
{
	public static class ApplicationConcreteMixinMethods
	{
		public static ApplicationModel FindApplicationModelByNameFromDb(this IFindApplicationModelByNameFromMsSqlDb implementation, string name)
		{
			var row = implementation.Db.Single<ApplicationTable>(x => x.Name == name);
			var model = row.ToApplicationModel();
			return model;
		}


		public static ApplicationModel FindApplicationModelByGlobalId(this IFindApplicationModelByGlobalIdFromMsSqlDb implementation, Guid globalId)
		{
			var row = implementation.Db.Single<ApplicationTable>(x => x.GlobalId == globalId);
			var model = row.ToApplicationModel();
			return model;
		}
	}
}