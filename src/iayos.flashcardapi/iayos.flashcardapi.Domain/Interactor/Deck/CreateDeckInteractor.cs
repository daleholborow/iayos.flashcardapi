using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using iayos.extensions;
using iayos.flashcardapi.Domain.Infrastructure;
using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.Deck.Dto;
using iayos.flashcardapi.ServiceModel.Deck.Message;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Interactor.Deck {

	public class CreateDeckInteractor : IInteractor<CreateDeckMessage, CreateDeckMessageResponse>
	{


		ICreateDeckGateway _gateway;


		public CreateDeckInteractor(ICreateDeckGateway gateway)
		{
			_gateway = gateway;
			_gateway = new InMemoryDeckModelRepository();
			//_gateway = new InMemoryModelRepository<DeckModel>();
		}


		public CreateDeckMessageResponse Handle(CreateDeckMessage request)
		{
			//_gateway.BeginTransaction();

			var deckModel = new DeckModel(); // request.ToDeckModel();


			//var existingDeckModel = _gateway.Get(-1);

			//deckModel = _gateway.Save(deckModel, x => x.DeckId);
			deckModel = _gateway.Save(deckModel);

			//_gateway.CommitTransaction();

			var payload = deckModel.ConvertTo<DeckDto>();
			return new CreateDeckMessageResponse {Result = payload};
		}


		/*private IInsertDocumentGateway _insertDocumentGateway;

		public InsertDocumentInteractor(
			IInsertDocumentGateway insertDocumentGateway
		)
		{
			_insertDocumentGateway = insertDocumentGateway;
		}


		/// <inheritdoc />
		public InsertDocumentMessageResponse Handle(InsertDocumentMessage request)
		{
			_insertDocumentGateway.BeginTransaction();
			//_insertDocumentGateway.IsQuestionnaireActive(request.QuestionnaireId);

			//var documentEntity = request.ToDocumentEntity();
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

	public interface ICreateDeckGateway : IRepository<int, DeckModel>/*, ITransactionalGateway*/ { }



	public class InMemoryDeckModelRepository : ICreateDeckGateway {

		private static readonly Dictionary<int, DeckModel> Store = new Dictionary<int, DeckModel>();

		/// <inheritdoc />
		public DeckModel Get(int id) { return Store[id]; }


		/// <inheritdoc />
		public DeckModel Save(DeckModel entity) { throw new NotImplementedException(); }

	}


	public interface IRepository<TKey, TTable>
	{
		

		TTable Get(int id);


		/// <inheritdoc />
		TTable Save(TTable entity);

	}


	public interface IDynamicKeyRepository<TKey, TTable> {

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
			var expr = (MemberExpression)propertySelector.Body;
			var prop = (PropertyInfo)expr.Member;

			var entityId = (int)prop.GetValue(entity);

			if (entityId == 0) entityId = Store.Count;

			prop.SetValue(entity, entityId, null);

			Store[entityId] = entity;

			return default(TTable);
		}

	}

}