using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.DomainGateway.Db.MSSQL.Tables
{
	public abstract class AuditableTable
	{
		public bool IsDeleted { get; set; }

		[RowVersion]
		public ulong RowVersion { get; set; }

	}

}
