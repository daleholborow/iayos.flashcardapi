﻿using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application.Find;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Application
{
	public class FindApplicationGateway : IFindApplicationGateway, IHasDbConnection
	{
		public IDbConnection Db { get; set; }


		public ApplicationModel FindApplicationByName(string applicationName)
		{
			var application = ConcreteDomainMixinMethods.FindApplicationByName(this, applicationName);
		return application;
		}


		public ApplicationModel FindApplicationByGlobalId(Guid globalId)
		{
			var application = ConcreteDomainMixinMethods.FindApplicationByGlobalId(this, globalId);
			return application;
		}
	}
}