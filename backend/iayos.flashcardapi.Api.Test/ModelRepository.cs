using System.Collections.Generic;
using System.Linq;
using iayos.flashcardapi.DomainModel.Infrastructure;

namespace iayos.flashcardapi.Api.Test
{
	/// <summary>
	/// In general, use the iayosRepository for convenience
	/// </summary>
	/// <typeparam name="TDomainModel"></typeparam>
	public class ModelRepository<TDomainModel>
		where TDomainModel : IDomainModel
	{
		private readonly Dictionary<long, TDomainModel> Store = new Dictionary<long, TDomainModel>();


		public TDomainModel Get(long id)
		{
			return Store[id];
		}


		public List<TDomainModel> GetAll()
		{
			return Store.Select(x => x.Value).ToList();
		}


		public TDomainModel Save(TDomainModel entity)
		{
			if (entity.Id == 0)
			{
				entity.Id = Store.Count + 1;
			}

			Store[entity.Id] = entity;

			return entity;
		}
	}
}