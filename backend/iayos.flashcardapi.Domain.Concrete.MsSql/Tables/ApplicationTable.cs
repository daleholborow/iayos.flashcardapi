using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Tables
{

	[Alias("Application")]
	public class ApplicationTable : AuditableTable 
    {

		[PrimaryKey]
		public Guid ApplicationId { get; set; }

		[StringLength(0, 100)]
		public string Name { get; set; }

		[StringLength(0,4000)]
		public string Description { get; set; }

		[Reference]
		public List<DeckTable> Decks { get; set; } = new List<DeckTable>();


	    [Reference]
	    public List<DeckCategoryTable> DeckCategories { get; set; } = new List<DeckCategoryTable>();

	}
}
