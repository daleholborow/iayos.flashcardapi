namespace iayos.flashcardapi.Domain.Infrastructure
{

	/// <summary>
	/// Defines the interaction of a UseCase, based on an incoming RequestMessage and an outgoing ResponseMessage
	/// Based a lot on the works of:
	/// https://medium.com/@stephanhoekstra/clean-architecture-in-net-8eed6c224c50#.1p6jylhmc
	/// and to a lesser extent
	/// http://blog.cleancoder.com/uncle-bob/2016/01/04/ALittleArchitecture.html
	/// https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html
	/// 
	/// </summary>
	/// <typeparam name="TRequestMessage"></typeparam>
	/// <typeparam name="TResponseMessage"></typeparam>
	public interface IInteractor<TRequestMessage, TResponseMessage>
	{
		TResponseMessage Handle(TRequestMessage request);
	}
}