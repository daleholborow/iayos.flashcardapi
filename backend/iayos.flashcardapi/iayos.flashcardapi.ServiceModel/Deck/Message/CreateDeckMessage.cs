using iayos.flashcardapi.ServiceModel.Deck.Dto;
using iayos.flashcardapi.ServiceModel.Infrastructure.Message;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Deck.Message
{

	public class CreateDeckMessage : IReturn<CreateDeckMessageResponse>
	{

		

	}


	public class CreateDeckMessageResponse : UnitPayloadResponse<DeckDto> { }

}
