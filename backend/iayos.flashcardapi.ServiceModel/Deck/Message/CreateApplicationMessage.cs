using iayos.flashcardapi.ServiceModel.Deck.Dto;
using iayos.flashcardapi.ServiceModel.Infrastructure.Message;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Deck.Message
{
	public class CreateApplicationMessage : IReturn<CreateApplicationMessageResponse>
	{
		
	}

	public class CreateApplicationMessageResponse : UnitPayloadResponse<ApplicationDto> { }

}