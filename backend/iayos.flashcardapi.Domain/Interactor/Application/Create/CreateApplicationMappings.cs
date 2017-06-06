using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Interactor.Application
{
	public static class CreateApplicationMappings
	{
		public static ApplicationModel ToApplicationModel(this CreateApplicationInput input)
		{
			var model = input.ConvertTo<ApplicationModel>();
			return model;
		}
	}
}