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

		public string Name { get; set; }

		[Reference]
		public IList<DeckTable> Decks { get; set; } = new List<DeckTable>();


	    [Reference]
	    public IList<DeckCategoryTable> DeckCatgories { get; set; } = new List<DeckCategoryTable>();

	}
}
