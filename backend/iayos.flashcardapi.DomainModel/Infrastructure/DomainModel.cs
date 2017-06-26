using System;

namespace iayos.flashcardapi.DomainModel.Infrastructure
{

	public abstract class DomainModel : IDomainModel
	{

		///// <inheritdoc />
		//public long Id { get; set; }

		/// <inheritdoc />
		//public Guid Id { get; set; } = Guid.NewGuid(); // TODO: SHOULD be generated as a sequential GUID to ensure it doesnt blow up DB indexing

	}

}
