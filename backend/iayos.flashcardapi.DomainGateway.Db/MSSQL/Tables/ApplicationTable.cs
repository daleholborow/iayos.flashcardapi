using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.DomainGateway.Db.MSSQL.Tables
{

	[Alias("Application")]
	public class ApplicationTable : AuditableTable 
    {
		[AutoIncrement]
		public int ApplicationId { get; set; }

		public string Name { get; set; }

		[Reference]
		public ICollection<DeckTable> Decks { get; set; } = new List<DeckTable>();

    }
}
