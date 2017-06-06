using System.Data;

namespace iayos.flashcardapi.Domain.Concrete.Application
{
	public interface IHasDbConnection
	{
		IDbConnection Db { get; set; }
	}
}