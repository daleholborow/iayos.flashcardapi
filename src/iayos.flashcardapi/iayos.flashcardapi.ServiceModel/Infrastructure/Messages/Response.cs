using System.Diagnostics;
using System.Runtime.Serialization;
using iayos.flashcardapi.ServiceModel.Infrastructure.Messages;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Infrastructure.Messages
{

	/// <summary>
	/// A base type to use for all responses, ensures that the resulting response message contains 
	/// the ResponseStatus, regardless of operation. 
	/// 
	/// </summary>
	/// <remarks>
	/// Some users had issues with IReturnVoid not serialising result status, so all our DELETE operations 
	/// will return the Response.
	/// See http://stackoverflow.com/questions/16015192/validation-exceptions-not-serialized-when-using-ireturnvoid-interface
	/// </remarks>
	[DebuggerStepThrough]
	public class Response : IHasResponseStatus
	{
		/// <summary>
		/// The ServiceStack-populated outcome of the operation
		/// </summary>
		[DataMember(Order = 1)]
		public ResponseStatus ResponseStatus { get; set; }
	}


	/// <summary>
	/// Response message to return a data payload for a SINGLE record
	/// </summary>
	/// <typeparam name="TPayloadDto"></typeparam>
	[DebuggerStepThrough]
	public class Response<TPayloadDto> : Response
	{

		[DataMember(Order = 2)]
		public TPayloadDto Result { get; set; }


		public Response() { }


		public Response(TPayloadDto result)
		{
			Result = result;
		}

	}

}






