using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.DomainGateway.Db.MSSQL.Tables
{

	[Alias("Application")]
	public class ApplicationTable : AuditableTable 
    {
		[AutoIncrement]
		public int ApplicationId { get; set; }

		public string Name { get; set; }

    }
}
