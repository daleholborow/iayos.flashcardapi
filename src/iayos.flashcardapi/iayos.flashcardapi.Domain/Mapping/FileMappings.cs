using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.FileSystem.Message;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Mapping
{

	public static class FileMappings
	{

		public static FileModel ToFileModel(this UploadFileMessage message)
		{
			if (message == null) return null;
			var model = message.ConvertTo<FileModel>();
			//model.FileSizeBytes = message.FileSizeBytes;
			// TODO init file extension etc
			return model;
		}

	}

}
