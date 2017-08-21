using iayos.flashcardapi.Domain.Dto.Application;
using iayos.flashcardapi.DomainModel.Models;
using ServiceStack;

namespace iayos.flashcardapi.Api.Endpoints
{
	public static class ApplicationMappings
	{
		public static ApplicationDto ToApplicationDto(this ApplicationModel model)
		{
			var dto = model.ConvertTo<ApplicationDto>();
			return dto;
		}
	}
}