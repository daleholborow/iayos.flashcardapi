using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace iayos.flashcardapi.Api.Test
{
	public static class LambdaExtensions
	{
		public static void SetPropertyValue<TObject, TProperty>(this TObject target, Expression<Func<TObject, TProperty>> memberLambda, object value)
		{
			var memberSelectorExpression = memberLambda.Body as MemberExpression;
			if (memberSelectorExpression != null)
			{
				var property = memberSelectorExpression.Member as PropertyInfo;
				if (property != null)
				{
					property.SetValue(target, value, null);
					return;
				}
			}
			throw new Exception("Couldnt find property I guess");
		}


		public static TProperty GetPropertyValue<TObject, TProperty>(this TObject target, Expression<Func<TObject, TProperty>> memberLambda)
		{
			var memberSelectorExpression = memberLambda.Body as MemberExpression;
			if (memberSelectorExpression != null)
			{
				var property = memberSelectorExpression.Member as PropertyInfo;
				if (property != null)
				{
					return (TProperty)property.GetValue(target);
				}
			}
			throw new Exception("Couldnt find property I guess");
		}


		public static ICollection<TProperty> GetPropertyValue<TObject, TProperty>(this TObject target, Expression<Func<TObject, ICollection<TProperty>>> memberLambda)
		{
			var memberSelectorExpression = memberLambda.Body as MemberExpression;
			if (memberSelectorExpression != null)
			{
				var property = memberSelectorExpression.Member as PropertyInfo;
				if (property != null)
				{
					return (ICollection<TProperty>)property.GetValue(target);
				}
			}
			throw new Exception("Couldnt find property I guess");
		}
	}
}