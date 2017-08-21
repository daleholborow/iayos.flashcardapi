using System;
using System.Collections.Generic;

namespace iayos.flashcardapi.DomainModel.UtilityModels
{

	public class ChildrenToKeyTransporter<TParentKey, TChild> where TParentKey : struct
	{
		private IDictionary<TParentKey, List<TChild>> Records { get; } = new Dictionary<TParentKey, List<TChild>>();

		public void PairChildToParent(TParentKey parentKey, TChild child)
		{
			Records[parentKey] = Records[parentKey] ?? new List<TChild>();
			Records[parentKey].Add(child);
		}

		public void PairChildrenToParent(TParentKey parentKey, ICollection<TChild> child)
		{
			Records[parentKey] = Records[parentKey] ?? new List<TChild>();
			Records[parentKey].AddRange(child);
		}

		public List<TChild> GetChildrenByParent(TParentKey parentKey)
		{
			return Records[parentKey];
		}
	}


	public class ChildrenToKeyTransporter<TChild> : ChildrenToKeyTransporter<Guid, TChild>
	{
	}
}