using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.Domain.Interactor.Deck.Create;
using iayos.flashcardapi.DomainModel.Models;

namespace iayos.flashcardapi.Domain.Interactor.Deck.CreateDeck
{
	public class CreateDeckInteractor : IInteractor<CreateDeckInput, CreateDeckOutput>
	{
		private readonly ICreateDeckGateway _gateway;
		private ICreateDeckValidator _validator;


		public CreateDeckInteractor(ICreateDeckGateway gateway, ICreateDeckValidator validator)
		{
			_gateway = gateway;
			_validator = validator;
		}


		public CreateDeckOutput Handle(UserModel agent, CreateDeckInput input)
		{
			//_gateway.BeginTransaction();

			var deckModel = input.ToDeckModel();

			var deckId = _gateway.Insert(deckModel);
			

			//var existingDeckModel = _gateway.Get(-1);

			//deckModel = _gateway.Save(deckModel, x => x.DeckId);
			//deckModel = _gateway.Save(deckModel);

			//_gateway.CommitTransaction();

			//var payload = deckModel.ConvertTo<DeckDto>();
			return new CreateDeckOutput {DeckId = -666};
		}


		/*private IInsertDocumentGateway _insertDocumentGateway;

		public InsertDocumentInteractor(
			IInsertDocumentGateway insertDocumentGateway
		)
		{
			_insertDocumentGateway = insertDocumentGateway;
		}


		/// <inheritdoc />
		public InsertDocumentMessageResponse Handle(InsertDocumentMessage input)
		{
			_insertDocumentGateway.BeginTransaction();
			//_insertDocumentGateway.IsQuestionnaireActive(input.QuestionnaireId);

			//var documentEntity = input.ToDocumentEntity();
			var documentEntity = new DocumentModel();
			documentEntity.DocumentId = _insertDocumentGateway.InsertDocument(documentEntity);

			_insertDocumentGateway.CommitTransaction();

			return new InsertDocumentMessageResponse();
		}*/
	}


	//public abstract class TransactionalGateway : ITransactionalGateway
	//{

	//	/// <inheritdoc />
	//	public void BeginTransaction() { throw new NotImplementedException(); }


	//	/// <inheritdoc />
	//	public void CommitTransaction() { throw new NotImplementedException(); }


	//	/// <inheritdoc />
	//	public void RollbackTransaction() { throw new NotImplementedException(); }

	//}

	/*public interface ICreateDeckGateway : IRepository<int, DeckModel> /*, ITransactionalGateway#1#
	{
	}


	public class InMemoryDeckModelRepository : ICreateDeckGateway
	{
		private static readonly Dictionary<int, DeckModel> Store = new Dictionary<int, DeckModel>();

		/// <inheritdoc />
		public DeckModel Get(int id)
		{
			return Store[id];
		}


		/// <inheritdoc />
		public DeckModel Save(DeckModel entity)
		{
			throw new NotImplementedException();
		}
	}


	public interface IRepository<TKey, TTable>
	{
		TTable Get(int id);


		/// <inheritdoc />
		TTable Save(TTable entity);
	}


	public interface IDynamicKeyRepository<TKey, TTable>
	{
		TTable Get(int id);

		TTable Save(TTable entity, Expression<Func<TTable, int>> propertySelector);
	}


	public class InMemoryModelDynamicKeyRepository<TTable> : IDynamicKeyRepository<int, TTable>
	{
		private static readonly Dictionary<int, TTable> Store = new Dictionary<int, TTable>();


		public TTable Get(int id)
		{
			return Store[id];
		}


		public TTable Save(TTable entity, Expression<Func<TTable, int>> propertySelector)
		{
			var expr = (MemberExpression) propertySelector.Body;
			var prop = (PropertyInfo) expr.Member;

			var entityId = (int) prop.GetValue(entity);

			if (entityId == 0) entityId = Store.Count;

			prop.SetValue(entity, entityId, null);

			Store[entityId] = entity;

			return default(TTable);
		}
	}*/
}