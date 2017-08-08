using System;
using System.Data;
using iayos.flashcardapi.Domain.Concrete.Application;
using iayos.flashcardapi.Domain.Interactor.Card.CreateCard;
using iayos.flashcardapi.DomainModel.Models;
using iayos.sequentialguid;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.Card.CreateCard
{
	public class CreateCardGateway : FlashCardGateway, ICreateCardGateway, IGetApplicationByIdFromMsSqlDb
	{
		public CreateCardGateway(IDbConnection dbConnection, ISequentialGuidGenerator guidGenerator) : base(dbConnection, guidGenerator)
		{
		}


		public Guid Insert(CardModel card)
		{
			card.CardId = GuidGenerator.NewSequentialGuid();
			var entity = card.ToCardTable();
			Db.Insert(entity);
			return entity.CardId;
		}

		public ApplicationModel GetApplicationById(Guid applicationId)
		{
			var application = this.GetApplicationByIdFromDb(applicationId);
			if (application == null) throw new Exception("NotFound");
			return application;

		}
	}
}