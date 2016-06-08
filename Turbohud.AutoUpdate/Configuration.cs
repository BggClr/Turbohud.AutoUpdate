using System;
using System.Configuration;

namespace Turbohud.AutoUpdate
{
	public class Configuration
	{
		public static Uri ReleasesPageUrl => new Uri(ConfigurationManager.AppSettings["ReleasesUrl"]);
		public static string DirectxVersion => ConfigurationManager.AppSettings["DirectxVersion"];
	}
}