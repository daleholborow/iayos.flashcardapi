using System.Diagnostics;
using System.Runtime.Serialization;

namespace iayos.flashcardapi.ServiceModel.Infrastructure.Message
{

	/// <summary>
	/// Response message to return a data payload for a SINGLE record (i.e. a single unit of data)
	/// </summary>
	/// <typeparam name="TPayloadDto"></typeparam>
	[DebuggerStepThrough]
	public class UnitPayloadResponse<TPayloadDto> : Response<TPayloadDto>
	{

		[DataMember(Order = 2)]
		public TPayloadDto Result { get; set; }


		public UnitPayloadResponse() { }


		public UnitPayloadResponse(TPayloadDto result)
		{
			Result = result;
		}


	}

}