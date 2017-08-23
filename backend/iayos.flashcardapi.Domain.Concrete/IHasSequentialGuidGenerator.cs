using iayos.sequentialguid;

namespace iayos.flashcardapi.Domain.Concrete
{
	public interface IHasSequentialGuidGenerator
	{
		ISequentialGuidGenerator GuidGenerator { get; }
	}
}