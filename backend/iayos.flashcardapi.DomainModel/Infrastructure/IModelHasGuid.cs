using System;

namespace iayos.flashcardapi.DomainModel.Infrastructure
{
	/// <summary>
	/// Will have a globally unique identifier
	/// </summary>
	public interface IModelHasGuid
	{

		/// <summary>
		/// Property to store globally unique id (TODO: SHOULD be generated as a sequential GUID to ensure it doesnt blow up DB indexing)
		/// </summary>
		Guid Id { get; set; }

	}

}