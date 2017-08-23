using System.Reflection;
using iayos.core.db.deploy;
using iayos.flashcardapi.Domain.Concrete.MsSql.Deploy.Transitions;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Deploy.Infrastructure
{
	/// <summary>
	/// We need a way to tell our deployment host *where* to find the deployment class objects 
	/// scripts that will be used for this deployment. Will also detect embedded .sql files, which 
	/// kinda breaks our Single Responsibility kick, but its from DbUp, watcha gonna do?
	/// </summary>
	public class DeploymentEmbeddedResourceSource : IDbDeploymentEmbeddedResourceSource
	{
		public Assembly ScriptsAssembly => typeof(Sql001CreateDatabase).Assembly;
	}
}