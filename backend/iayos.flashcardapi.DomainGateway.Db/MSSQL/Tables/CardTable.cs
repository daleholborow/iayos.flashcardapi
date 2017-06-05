using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.DomainGateway.Db.MSSQL.Tables
{
	[Alias("Card")]
	public class CardTable : AuditableTable
	{
		[AutoIncrement]
		public int CardId { get; set; }

		public int Order { get; set; }

	}
}