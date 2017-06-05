using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace iayos.flashcardapi.Api.Test
{
	public static class ModelLinker
	{
		public static void LinkOneToOne<TOneLeft, TOneRight>
		(
			TOneLeft leftObject,
			Expression<Func<TOneLeft, TOneRight>> selectPropertyOfLeftObject,
			TOneRight rightObject,
			Expression<Func<TOneRight, TOneLeft>> selectPropertyOfRightObject
		)
		{
			leftObject.SetPropertyValue(selectPropertyOfLeftObject, rightObject);
			rightObject.SetPropertyValue(selectPropertyOfRightObject, leftObject);
		}


		/// <summary>
		/// For ObjectA with CollectionB, link in a new B into the CollectionB property
		/// </summary>
		/// <typeparam name="TOneLeft"></typeparam>
		/// <typeparam name="TOneRight"></typeparam>
		/// <param name="leftObject"></param>
		/// <param name="selectCollectionOfRightObjectsPropertyOfLeftObject"></param>
		/// <param name="rightObject"></param>
		/// <param name="selectSingleLeftObjectPropertyOfRightObject"></param>
		public static void LinkOneToOne<TOneLeft, TOneRight>
		(
			TOneLeft leftObject,
			Expression<Func<TOneLeft, ICollection<TOneRight>>> selectCollectionOfRightObjectsPropertyOfLeftObject,
			TOneRight rightObject,
			Expression<Func<TOneRight, TOneLeft>> selectSingleLeftObjectPropertyOfRightObject
		)
		{
			var propertyOfLeftObject = leftObject.GetPropertyValue(selectCollectionOfRightObjectsPropertyOfLeftObject);
			rightObject.SetPropertyValue(selectSingleLeftObjectPropertyOfRightObject, leftObject);
			if (propertyOfLeftObject.Contains(rightObject) == false)
			{
				propertyOfLeftObject.Add(rightObject);
			}
		}


		public static void LinkOneToMany<TOneLeft, TManyRight>
		(
			TOneLeft leftObject,
			Expression<Func<TOneLeft, ICollection<TManyRight>>> selectCollectionOfRightObjectsPropertyOfLeftObject,
			ICollection<TManyRight> rightObjects,
			Expression<Func<TManyRight, TOneLeft>> selectSingleLeftObjectPropertyOfRightObject
		)
		{
			var childrenOfLeftObject = leftObject.GetPropertyValue(selectCollectionOfRightObjectsPropertyOfLeftObject);
			foreach (var rightObject in rightObjects)
			{
				// Assign the parent object to each child (e.g. Order to Item)
				rightObject.SetPropertyValue(selectSingleLeftObjectPropertyOfRightObject, leftObject);
				// If the parent's collection of child items doesnt contain the current one, add it now
				if (childrenOfLeftObject.Contains(rightObject) == false)
				{
					childrenOfLeftObject.Add(rightObject);
				}
			}
		}


		public static void LinkManyToMany<TOneLeft, TManyRight>
		(
			TOneLeft leftObject,
			Expression<Func<TOneLeft, ICollection<TManyRight>>> selectCollectionOfRightObjectsPropertyOfLeftObjects,
			ICollection<TManyRight> rightObjects,
			Expression<Func<TManyRight, List<TOneLeft>>> selectSingleLeftObjectPropertyOfRightObject
		)
		{
			var childrenOfLeftObject = leftObject.GetPropertyValue(selectCollectionOfRightObjectsPropertyOfLeftObjects);
			foreach (var rightObject in rightObjects)
			{
				// Assign the parent object to each child (e.g. Order to Item)
				var parentsOfRightObject = rightObject.GetPropertyValue(selectSingleLeftObjectPropertyOfRightObject);
				if (parentsOfRightObject.Contains(leftObject) == false)
				{
					parentsOfRightObject.Add(leftObject);
				}

				// If the parent's collection of child items doesnt contain the current one, add it now
				if (childrenOfLeftObject.Contains(rightObject) == false)
				{
					childrenOfLeftObject.Add(rightObject);
				}
			}
		}

	}
}