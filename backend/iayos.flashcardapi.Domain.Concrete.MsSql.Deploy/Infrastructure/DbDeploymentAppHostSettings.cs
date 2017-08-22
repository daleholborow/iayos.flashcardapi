using System;
using System.ComponentModel;
using System.Configuration;
using iayos.core.db.deploy;

namespace iayos.flashcardapi.Domain.Concrete.MsSql.Deploy.Infrastructure
{
	/// <summary>
	/// Define the values that will be used when performing deployments (what db to target, whether to destroy 
	/// the db - as we do when performing test cases, for example - before applying migrations]!)
	/// </summary>
	public class DbDeploymentAppHostSettings : IDbDeploymentAppHostSettings
	{

		public string TargetDbConnectionString => ConfigurationManager.ConnectionStrings["flashcardapi.ConnString"].ConnectionString;


		public string ScriptSourceFolderPath => Get<string>("flashcardapi:ScriptSourceFolderPath", null);


		public bool DangerDangerNukeTheTargetDbBeforeDeployDangerDanger => Get("flashcardapi:DangerDangerNukeTheTargetDbBeforeDeployDangerDanger", false);


		public string NukeableDbNameSuffix => Get("flashcardapi:NukeableDbNameSuffix", "NUKEABLE");


		public T Get<T>(string appSettingKey, T defaultValue)
		{
			string appSettingValueString = ConfigurationManager.AppSettings[appSettingKey];
			try
			{
				T appSettingValue = Convert<T>(appSettingValueString);
				return appSettingValue;
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}

		private T Convert<T>(string input)
		{
			var converter = TypeDescriptor.GetConverter(typeof(T));
			if (converter != null) return (T)converter.ConvertFromString(input);
			return default(T);
		}

	}
}
