using System;
using System.Data;
using DbUp.Engine;
using iayos.core.db.deploy;
using iayos.flashcardapi.Domain.Concrete.MsSql.Tables;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Deploy.Transitions
{
	public class Sql001CreateDatabase : DbTransition, IScript
	{

		public override void Apply(IDbConnectionFactory dbConnectionFactory)
		{

			new OrmLiteAuthRepositoryInitializer().Deploy();

			using (var db = dbConnectionFactory.OpenDbConnection())
			{
				Console.WriteLine("Creating the application tables...");

				db.CreateTableIfNotExists<ApplicationTable>();
				db.CreateTableIfNotExists<DeckCategoryTable>();
				db.CreateTableIfNotExists<DeckTable>();
				db.CreateTableIfNotExists<CardTable>();

				Console.WriteLine("Application tables created!");
			}
		}


		public string ProvideScript(Func<IDbCommand> commandFactory)
		{
			Deploy();
			return string.Empty;
		}

	}
}
