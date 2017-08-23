using DbUp.Engine;
using iayos.flashcardapi.Domain.Concrete.MsSql.Deploy.Infrastructure;
using Xunit;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Deploy
{
	class Program
	{
		static void Main(string[] args)
		{

			DemonstrateHowToDestroyDatabaseAndRecreateFromTheGroundUp();

		}


		public static void DemonstrateHowToDestroyDatabaseAndRecreateFromTheGroundUp()
		{
			var deployer = new ApiDbDeployer();
			var result = deployer.DeployTheDb();
			deployer.Host.ReportToConsole(result);
		}

	}

	public class ApiDbDeployer
	{
		private DbDeploymentAppHost _host;
		public DbDeploymentAppHost Host => _host ?? (_host = new DbDeploymentAppHost());

		public ApiDbDeployer()
		{
			// empty
		}

		[Fact]
		public DatabaseUpgradeResult DeployTheDb()
		{
			Host.Init();
			Host.AttemptToNukeTargetDatabase();
			var result = Host.ApplyTransitions();
			return result;
		}
	}
}
