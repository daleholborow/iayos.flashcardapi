using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Interactor.Application
{
	public static class ApplicationMappings
	{
		public static ApplicationModel ToApplicationModel(this CreateApplicationInput input)
		{
			var model = input.ConvertTo<ApplicationModel>();
			return model;
		}
	}
}