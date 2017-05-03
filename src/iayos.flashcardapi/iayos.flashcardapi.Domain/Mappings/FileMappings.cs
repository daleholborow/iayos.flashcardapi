using iayos.flashcardapi.DomainModel.Models;
using iayos.flashcardapi.ServiceModel.FileSystem.Messages;
using ServiceStack;

namespace iayos.flashcardapi.Domain.Mappings
{

	public static class FileMappings
	{

		public static FileModel ToFileModel(this FileMessage message)
		{
			if (message == null) return null;
			var model = message.ConvertTo<FileModel>();
			//model.FileSizeBytes = message.FileSizeBytes;
			// TODO init file extension etc
			return model;
		}

	}

	//public static class QuestionnaireMappings
	//{

	//	public static QuestionnaireModel ToQuestionnaireModel(this CreateQuestionnaireMessage message)
	//	{
	//		if (message == null) return null;
	//		var model = message.ConvertTo<QuestionnaireModel>();
	//		return model;
	//	}

	//}

}