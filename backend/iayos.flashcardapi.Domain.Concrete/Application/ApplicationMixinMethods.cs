using System;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Application
{
	public static class ApplicationMixinMethods
	{
		public static ApplicationModel FindApplicationModelByNameFromDb(
			this IFindApplicationModelByNameFromMsSqlDb implementation, string name)
		{
			var row = implementation.Db.Single<ApplicationTable>(x => x.Name == name);
			var model = row.ToApplicationModel();
			return model;
		}


		public static ApplicationModel FindApplicationModelById(
			this IFindApplicationModelByIdFromMsSqlDb implementation, Guid globalId)
		{
			var row = implementation.Db.Single<ApplicationTable>(x => x.ApplicationId == globalId);
			var model = row.ToApplicationModel();
			return model;
		}
	}
}