using System;
using System.Data;
using iayos.flashcardapi.Domain.Interactor.Application;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Concrete.Application.Create
{
	public class CreateApplicationValidator : FlashCardValidator, ICreateApplicationValidator,
		IFindApplicationModelByNameFromMsSqlDb
	{
		public CreateApplicationValidator(IDbConnection dbConnection) : base(dbConnection)
		{
		}

		public void ThrowOnInsufficientPermissions(UserModel agent)
		{
			//throw new NotImplementedException("not checking for permmisssions properly yet");
			// TODO perm,ss
		}


		public void ThrowOnInvalidApplicationName(string applicationName)
		{
			applicationName = applicationName.Trim();

			// see if name is unique and throw if not
			var application = this.FindApplicationModelByNameFromDb(applicationName);
			if (application != null) throw new Exception("Not allowed duplicate application names");
			if (applicationName.Contains("dale")) throw new Exception("Can't have your name in here while testing mate");
		}
	}
}