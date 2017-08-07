using iayos.flashcardapi.Domain.Dto.Application;
using iayos.flashcardapi.Domain.Interactor.Deck;
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


		public static ApplicationDto ToApplicationDto(this ApplicationModel model)
		{
			var dto = model.ConvertTo<ApplicationDto>();
			return dto;
		}


		public static DeckCategoryDto ToDeckCategoryDto(this DeckCategoryModel model)
		{
			var dto = model.ConvertTo<DeckCategoryDto>();
			dto.Decks = model.Decks.ConvertAll(x => x.ToDeckDto());
			return dto;
		}
	}


	

	
}