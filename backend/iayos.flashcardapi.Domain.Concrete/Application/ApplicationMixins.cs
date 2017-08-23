using System;
using System.Collections.Generic;
using System.Linq;
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


		public static ApplicationModel FindApplicationByIdFromDb(
			this IFindApplicationByIdFromMsSqlDb implementation, Guid applicationId)
		{
			var row = implementation.Db.Select<ApplicationTable>(x => x.ApplicationId == applicationId).FirstOrDefault();
			var model = row?.ToApplicationModel();
			return model;
		}


		public static ApplicationModel GetApplicationByIdFromDb(
			this IGetApplicationByIdFromMsSqlDb implementation, Guid applicationId)
		{
			var row = implementation.Db.SingleById<ApplicationTable>(applicationId);
			if (row == null) throw new Exception("ApplicationId Not Found by Id: " + applicationId);
			return row.ToApplicationModel();
		}
	}
}