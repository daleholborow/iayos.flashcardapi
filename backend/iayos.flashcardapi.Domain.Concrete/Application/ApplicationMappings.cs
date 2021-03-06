﻿using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Concrete.Application
{
	internal static class ApplicationMappings
	{
		public static ApplicationModel ToApplicationModel(this ApplicationTable row)
		{
			if (row == null) return null;
			var model = row.ConvertTo<ApplicationModel>();
			return model;
		}

		public static ApplicationTable ToApplicationTable(this ApplicationModel model)
		{
			var row = model.ConvertTo<ApplicationTable>();
			return row;
		}
	}
}