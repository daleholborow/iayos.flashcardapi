using System.Data;

namespace iayos.flashcardapi.Domain.Concrete
{
	public interface IHasDbConnection
	{
		IDbConnection Db { get; }
	}
}