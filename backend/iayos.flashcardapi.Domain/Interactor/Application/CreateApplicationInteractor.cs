using System;
using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.ServiceModel.Deck.Message;

namespace iayos.flashcardapi.Domain.Interactor.Application
{
	public class CreateApplicationInteractor : IInteractor<CreateApplicationMessage, CreateApplicationMessageResponse>
	{
		public CreateApplicationMessageResponse Handle(CreateApplicationMessage request)
		{
			throw new NotImplementedException();
		}
	}
}
