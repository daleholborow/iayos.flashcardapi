using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.DomainGateway.Db.MSSQL.Tables
{
	[Alias("User")]
	public class UserTable : AuditableTable
	{
		[AutoIncrement]
		public int UserId { get; set; }

		public string GivenName { get; set; }

		public string FamilyName { get; set; }

	}
}