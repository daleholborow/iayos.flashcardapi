using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iayos.flashcardapi.ServiceModel.Infrastructure.Messages
{

	/// <summary>
	/// Response message to return a data payload for a COLLECTION of records. Note that the payload 
	/// collection 'Results' is intentionally set to the same name as the AutoQuery->QueryResponse naming,
	/// so that across the board, we know that for any  ~Service endpoint, if it returns a single item the result
	/// will be found in Response.Result and for endpoints that return collections, the data will always be found 
	/// in ListResponse.Results, along with the total count in ListResponse.Total
	/// </summary>
	/// <typeparam name="TPayloadDto"></typeparam>
	public class ListResponse<TPayloadDto> : Response
	{

		/// <summary>
		/// How many results are there in total that match the list search conditions
		/// </summary>
		[DataMember(Order = 2)]
		public long Total => _total ?? Results.Count;
		public long? _total;


		[DataMember(Order = 3)]
		public long Offset { get; set; }


		[DataMember(Order = 4)]
		public List<TPayloadDto> Results { get; set; } = new List<TPayloadDto>();

	}

}