using System;
using System.Collections.Generic;
using iayos.flashcardapi.DomainModel.Infrastructure;

namespace iayos.flashcardapi.Api.Test
{
	public class IayosRepository
	{
		private readonly Dictionary<Type, ModelRepository<IDomainModel>> _repoStore =
			new Dictionary<Type, ModelRepository<IDomainModel>>();


		private void Init<TDomainModel>()
			where TDomainModel : IDomainModel
		{
			if (_repoStore.ContainsKey(typeof(TDomainModel)) == false)
			{
				_repoStore.Add(typeof(TDomainModel), new ModelRepository<IDomainModel>());
			}
		}

		public TDomainModel Get<TDomainModel>(int id)
			where TDomainModel : class, IDomainModel, new()
		{
			Init<TDomainModel>();
			return _repoStore[typeof(TDomainModel)].Get(id) as TDomainModel;
		}


		public List<TDomainModel> GetAll<TDomainModel>()
			where TDomainModel : class, IDomainModel, new()
		{
			Init<TDomainModel>();
			var domainModels = _repoStore[typeof(TDomainModel)].GetAll() as List<TDomainModel> ?? new List<TDomainModel>();
			return domainModels;
		}


		public TDomainModel Save<TDomainModel>(TDomainModel entity)
			where TDomainModel : class, IDomainModel, new()
		{
			Init<TDomainModel>();
			return _repoStore[typeof(TDomainModel)].Save(entity) as TDomainModel;
		}

	}
}