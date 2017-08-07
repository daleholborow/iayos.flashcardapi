using iayos.flashcardapi.Domain.Dto.Application;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Interactor.Application.Get
{
	public static class GetApplicationMappings
	{

		public static ApplicationDto ToApplicationDto(this ApplicationModel model)
		{
			var dto = model.ConvertTo<ApplicationDto>();
			return dto;
		}

	}
}
