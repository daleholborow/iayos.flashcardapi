using System;
using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Tables
{
	[Alias("Score")]
	public class ScoreTable : AuditableTable
	{
		//[AutoIncrement]
		//public int ScoreId { get; set; }

		[PrimaryKey]
		public Guid ScoreId { get; set; }


		[References(typeof(CardTable))]
		public int CardId { get; set; }

		[Reference]
		public CardTable Card { get; set; }


		[References(typeof(UserTable))]
		public int UserId { get; set; }

		public UserTable User { get; set; }


		public int Correct { get; set; }

		public int Incorrect { get; set; }

		public decimal Accuracy
		{
			get
			{
				var denom = Correct + Incorrect;
				if (denom == 0)
				{
					return 0;
				}
				return ((decimal)Correct)/(denom);
			}
		}
	}
}