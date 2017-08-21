using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Tables
{
	[Alias("DeckCategory")]
	public class DeckCategoryTable : AuditableTable
	{
		[PrimaryKey]
		public Guid DeckCategoryId { get; set; }

		
		[Required]
		[References(typeof(ApplicationTable))]
		public Guid ApplicationId { get; set; }

		[Reference]
		public ApplicationTable Application { get; set; }


		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		[Reference]
		public List<DeckTable> Decks { get; set; }

	}
}