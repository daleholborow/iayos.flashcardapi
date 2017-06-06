﻿using System;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Application.Get
{
	public interface IGetApplicationGateway
	{
		ApplicationModel GetApplicationModelByGlobalId(Guid applicationGlobalId);
	}
}