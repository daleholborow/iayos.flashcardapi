using System;
using System.Collections.Generic;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Application
{
	public static class ApplicationMixins
	{
		public static List<ApplicationModel> FindApplicationsByNameFromDb(
			this IFindApplicationByNameFromMsSqlDb implementation, string name)
		{
			var rows = implementation.Db.Select<ApplicationTable>(x => x.Name == name);
			var models = rows.ConvertAll(x => x.ToApplicationModel());
			return models;
		}


		public static ApplicationModel FindApplicationById(
			this IFindApplicationByIdFromMsSqlDb implementation, Guid globalId)
		{
			var row = implementation.Db.Single<ApplicationTable>(x => x.ApplicationId == globalId);
			var model = row.ToApplicationModel();
			return model;
		}
	}
}