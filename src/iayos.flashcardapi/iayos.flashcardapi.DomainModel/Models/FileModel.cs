using System;

namespace iayos.flashcardapi.DomainModel.Models
{
	public class FileModel
	{

		public string Name { get; set; }


		public string Extension { get; set; }


		public long FileSizeBytes { get; set; }


		public DateTimeOffset ModifiedDate { get; set; }


		public byte[] Contents { get; set; }

	}
}
