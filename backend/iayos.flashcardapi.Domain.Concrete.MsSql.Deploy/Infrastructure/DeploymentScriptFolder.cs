using iayos.core.db.deploy;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Deploy.Infrastructure
{
	/// <summary>
	/// We need a way to tell our deployment host *where* to find the deployment .sql source 
	/// filesystem folder. NOT embedded scripts.
	/// </summary>
	public class DeploymentScriptFolder : IDbDeploymentScriptFolder
	{
		public string ScriptSourceFolderPath { get; }

		public DeploymentScriptFolder(string scriptSourceFolderFilePath)
		{
			ScriptSourceFolderPath = scriptSourceFolderFilePath;
		}
	}
}