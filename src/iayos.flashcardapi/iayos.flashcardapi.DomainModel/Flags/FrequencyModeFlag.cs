namespace iayos.flashcardapi.DomainModel.Flags
{

	public enum FrequencyModeFlag
	{

		/// <summary>
		/// Shuffle and pick from the deck cards uniformly when studying
		/// </summary>
		UNIFORMLY = 0,


		/// <summary>
		/// Custom algorithm to show cards more frequently the higher ranked they are the deck order (e.g. for "top 10 most common finnish words")
		/// </summary>
		POPULARITY

	}

}