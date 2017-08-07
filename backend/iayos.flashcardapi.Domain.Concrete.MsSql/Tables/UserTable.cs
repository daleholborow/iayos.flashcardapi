using System;
using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Tables
{
	[Alias("User")]
	public class UserTable : AuditableTable
	{
		//[AutoIncrement]
		//public int UserId { get; set; }

		[PrimaryKey]
		public Guid UserId { get; set; }

		public string GivenName { get; set; }

		public string FamilyName { get; set; }

	}
}