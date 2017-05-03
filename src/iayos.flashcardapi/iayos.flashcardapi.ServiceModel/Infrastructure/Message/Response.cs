using System.Diagnostics;
using System.Runtime.Serialization;
using ServiceStack;

namespace iayos.flashcardapi.ServiceModel.Infrastructure.Message
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
	public abstract class Response<TPayloadDto> : IHasResponseStatus, IReturn<TPayloadDto>
	{
		/// <summary>
		/// The ServiceStack-populated outcome of the operation
		/// </summary>
		[DataMember(Order = 1)]
		public ResponseStatus ResponseStatus { get; set; }
	}

}
