using System;
using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Tables
{
	[Alias("Card")]
	public class CardTable : AuditableTable
	{
		//[AutoIncrement]
		//public int CardId { get; set; }

		public Guid CardId { get; set; }

		public int Order { get; set; }

	}
}