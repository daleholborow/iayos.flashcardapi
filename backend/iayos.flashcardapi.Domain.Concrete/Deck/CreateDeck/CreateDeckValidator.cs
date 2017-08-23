//using System;
//using System.Data;
//using iayos.flashcardapi.Domain.Interactor.Deck.Create;
//using iayos.flashcardapi.DomainModel.Models;

//namespace iayos.flashcardapi.Domain.Concrete.Deck.CreateDeck
//{
//	public class CreateDeckValidator : FlashCardValidator, ICreateCardValidator,
//		IFindDeckByNameFromMsSqlDb
//	{
//		public CreateDeckValidator(IDbConnection dbConnection) : base(dbConnection)
//		{
//		}

//		public void ThrowOnInsufficientPermissions(UserModel agent)
//		{
//			//throw new NotImplementedException("not checking for permmisssions properly yet");
//			// TODO perm,ss
//		}


//		public void ThrowOnInvalidDeckName(string deckName)
//		{
//			deckName = deckName.Trim();

//			// see if name is unique and throw if not
//			var application = this.FindDeckByNameFromDb(deckName);
//			if (application != null) throw new Exception("Not allowed duplicate deck names");
//			if (deckName.Contains("dale")) throw new Exception("Can't have your name in here while testing mate");
//		}
//	}
//}
