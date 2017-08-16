using Funq;
using iayos.core.db.deploy;
using iayos.flashcardapi.Domain.Concrete.MsSql.Deploy.Transitions;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Deploy.Infrastructure
{
	public class DbDeploymentAppHost : ServiceStackAuthDbDeploymentAppHost
	{

		public DbDeploymentAppHost() : base("flashcardapi Deployment AppHost", typeof(Sql001CreateDatabase).Assembly)
		{
			DeploymentSettings = new DbDeploymentAppHostSettings();
		}


		public override void Configure(Container container)
		{
			base.Configure(container);

			container.RegisterAs<DeploymentEmbeddedResourceSource, IDbDeploymentEmbeddedResourceSource>();
			container.Register<IDbDeploymentScriptFolder>(
				c => new DeploymentScriptFolder(DeploymentSettings.ScriptSourceFolderPath));
		}

	}
}