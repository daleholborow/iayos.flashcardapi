using System;
using ServiceStack.DataAnnotations;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Tables
{
	public abstract class AuditableTable
	{

		public Guid GlobalId { get; set; }


		public bool IsDeleted { get; set; }

		[RowVersion]
		public ulong RowVersion { get; set; }

	}

}
