namespace iayos.flashcardapi.DomainModel.Infrastructure
{
	public interface IModelHasId
	{
		/// <summary>
		/// Per model-type primary key 
		/// </summary>
		long Id { get; set; }
	}
}