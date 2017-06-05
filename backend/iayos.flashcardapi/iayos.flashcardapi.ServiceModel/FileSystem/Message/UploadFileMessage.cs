using System;

namespace iayos.flashcardapi.ServiceModel.FileSystem.Message
{

	/// <summary>
	/// Incoming file payload for http multi type content upload
	/// </summary>
	public class UploadFileMessage
	{

		public string Name { get; set; }

		public string Extension { get; set; }

		public long FileSizeBytes { get; set; }

		public DateTimeOffset ModifiedDate { get; set; }

		//public bool IsTextFile { get; set; }


		public byte[] Contents { get; set; }

	}

}
