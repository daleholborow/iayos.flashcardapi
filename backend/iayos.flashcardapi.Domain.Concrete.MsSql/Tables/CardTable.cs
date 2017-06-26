using System;
using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Tables
{
	[Alias("Card")]
	public class CardTable : AuditableTable
	{

		[PrimaryKey]
		public Guid CardId { get; set; }


		[References(typeof(DeckTable))]
		public Guid DeckId { get; set; }

		[Reference]
		public DeckTable Deck { get; set; }


		public int Order { get; set; }



	}

}
