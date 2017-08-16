using iayos.flashcardapi.Domain.Concrete.MsSql.Deploy.Infrastructure;

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
			var something = new DbDeploymentAppHost();
			something.Init();
			something.AttemptToNukeTargetDatabase();
			something.ApplyTransitionsAndReport();
		}

	}
}
